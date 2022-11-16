using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(CapsuleCollider))]
	public class ThirdPersonCharacter : MonoBehaviour
	{
		[SerializeField] UnityEvent onJumped;
		[SerializeField] UnityEvent onJumpSwitchToggled;
		[SerializeField] float m_MovingTurnSpeed = 360;
		[SerializeField] float m_StationaryTurnSpeed = 180;
		[SerializeField] float m_JumpPower = 12f;
		[Range(1f, 4f)][SerializeField] float m_GravityMultiplier = 2f;
		[SerializeField] float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
		[SerializeField] float m_MoveSpeedMultiplier = 1f;
		[SerializeField] float m_RunSpeedMultiplier = 1.4f;
		[SerializeField] float m_AnimSpeedMultiplier = 1f;
		[SerializeField] float m_GroundCheckDistance = 0.1f;

		Rigidbody m_Rigidbody;
		public bool m_IsGrounded;
		float m_OrigGroundCheckDistance;
		const float k_Half = 0.5f;
		float m_TurnAmount;
		float m_ForwardAmount;
		Vector3 m_GroundNormal;
		float m_CapsuleHeight;
		Vector3 m_CapsuleCenter;
		CapsuleCollider m_Capsule;
		bool m_Crouching;

		[HideInInspector]
		public bool active = true;
		public Vector3 moveWatch;
		public bool readyJump;
		public float jumpTime = 0.2f;
		public float jumpTimer, cayoteTimer;
		public float minJumpPower = 150f, cayoteTime = 0.04f;
		public bool minJumpForMe;
		public float viewLayerMask;
		[HideInInspector]
		public jumpSwitch[] jumpSwitches;
		public float yVelocity;
		private bool hasJumped;
		private Vector3 velocityStore;

		// Step up stuff \/\/\/
		[Header("Steps")]
		public float maxStepHeight = 0.4f;              ///< The maximum a player can set upwards in units when they hit a wall that's potentially a step
		public float stepSearchOvershoot = 0.01f;       ///< How much to overshoot into the direction a potential step in units when testing. High values prevent player from walking up small steps but may cause problems.
		
		private List<ContactPoint> allCPs = new List<ContactPoint>();
		private Vector3 lastVelocity, preStepUp, playerModelOffset;
		public GameObject testStepUp;
		public bool stepUpAnimation;
		private float stepUpTimer = 1;

		// Float stuff
		public bool floating;
		public bool floatactive, floatOnce;
		public float floatingSpeed = 40000;
		public Transform playerHead;
		public float stepFrequency;
		[HideInInspector]
		public Transform headParent;
		private Vector3 headOffset, playerModelRot;
		private float floatTimer;

		private float _lastStepTime;
		private StepController _stepController;
		// Anim stuff
		private Animator playerAnim;
		void Start()
		{
			playerAnim = GetComponent<ThirdPerson.ThirdPersonUserControl>().playerAnim;

			_stepController = GetComponent<StepController>();
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Capsule = GetComponent<CapsuleCollider>();
			m_CapsuleHeight = m_Capsule.height;
			m_CapsuleCenter = m_Capsule.center;

			m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			m_OrigGroundCheckDistance = m_GroundCheckDistance;
			
			
			jumpSwitches = GameObject.FindObjectsOfType<jumpSwitch>();

			headParent = playerHead.parent.transform;

			playerModelOffset = headParent.localPosition;
			playerModelRot = headParent.localEulerAngles;
			headOffset = playerHead.localPosition;
		}
		private void Update() {
			//CheckGroundStatus();	
		}


		public void Move(Vector3 move, bool crouch, bool jump, Vector3 cameraDirection)
		{
			if(active){
				if((Mathf.Abs(move.x) > 0 || Mathf.Abs(move.z) > 0) && m_IsGrounded){
                	playerAnim.SetFloat("Blend", 1);
            	}else{
                	playerAnim.SetFloat("Blend", 0);
            	}

				if(floating){
					move = cameraDirection;
				}
				if(minJumpForMe){
					jump = true;
				}
				// convert the world relative moveInput vector into a local-relative
				// turn amount and forward amount required to head in the desired
				// direction.
				if (move.magnitude > 1f) move.Normalize();
				move = transform.InverseTransformDirection(move);
				move = Vector3.ProjectOnPlane(move, m_GroundNormal);
				m_TurnAmount = Mathf.Atan2(move.x, move.z);
				m_ForwardAmount = move.z;

				ApplyExtraTurnRotation();

				_lastStepTime += Time.fixedDeltaTime;
				// control and velocity handling is different when grounded and airborne:
				if (m_IsGrounded)
				{
					if (
						move.sqrMagnitude > 0.1f &&
					    _lastStepTime >= stepFrequency && _stepController != null &&
					    !_stepController.Equals(null))
					{
						_lastStepTime = 0;
						_stepController.PlayStepSound();
					}
					
					HandleGroundedMovement(jump);
					
				}
				else
				{
					HandleAirborneMovement();
				}
				CheckGroundStatus();

				ScaleCapsuleForCrouching(crouch);
				PreventStandingInLowHeadroom();

				if(Input.GetKey(KeyCode.Space) || minJumpForMe){
					if(readyJump){
						hasJumped = true;
						print("NormalJump");
						JumpHandler();
					}else{
						if(cayoteTimer < cayoteTime && !hasJumped){
						print("AirJump");
							JumpHandler();
						}
					}
				}else{
					readyJump = false;
				}
				if(m_IsGrounded){
					readyJump = false;
					hasJumped = false;
					jumpTimer = jumpTime;
					cayoteTimer = 0;
				}else{
					cayoteTimer += Time.deltaTime;
				}
				float isRunning = Input.GetKey(KeyCode.LeftShift) ? m_RunSpeedMultiplier : 1;
				//transform.Translate(move * Time.fixedDeltaTime * m_MoveSpeedMultiplier * isRunning);
				float yVel = m_Rigidbody.velocity.y;
				velocityStore = m_Rigidbody.velocity;
				m_Rigidbody.velocity = new Vector3(0, yVel, 0);
				if(!floating){
					m_Rigidbody.AddForce(transform.forward * Time.fixedDeltaTime * m_MoveSpeedMultiplier * isRunning * move.z * WallCheck(), ForceMode.Impulse);
				}
				moveWatch = move;
				minJumpForMe = false;

				yVelocity = m_Rigidbody.velocity.y;

				/*
				if(stepUpTimer < 1){
					stepUpTimer += Time.deltaTime * 8;
					playerModel.transform.localPosition = Vector3.Lerp(preStepUp, transform.localPosition + playerModelOffset, stepUpTimer);
				}else{
					playerModel.transform.parent = transform;
				}*/

				if(floating){
					if(!floatOnce){
						
						floatOnce = true;
					}
					if(yVelocity < 0 && !m_IsGrounded){
						floatactive = true;
					}
					if(floatactive){
						this.GetComponent<ConstantForce>().enabled = false;
						m_Rigidbody.useGravity = false;
						m_Rigidbody.velocity = new Vector3(0, yVel, 0);
						m_Rigidbody.AddForce(transform.forward * Time.fixedDeltaTime * floatingSpeed * WallCheck(), ForceMode.Impulse);
						headParent.gameObject.SetActive(false);

					}
					if(m_IsGrounded){
						floatTimer += Time.deltaTime;
						if(floatTimer > 0.2f){
							DisableFloating();
						}
					}else{
						floatTimer = 0;
					}
				}
			}
		}
		void JumpHandler(){
			//m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower * jumpTimer, m_Rigidbody.velocity.z);
			if(jumpTimer >= 0){
				if(jumpTimer == jumpTime){
					m_Rigidbody.velocity = new Vector3(0,0,0);
					m_Rigidbody.AddForce(Vector3.up * minJumpPower, ForceMode.Impulse);

					onJumped.Invoke();
					FlipJumpSwitches();
				}
				m_Rigidbody.AddForce(Vector3.up * m_JumpPower * jumpTimer, ForceMode.Acceleration);
					
				jumpTimer -= Time.deltaTime;
			}else{
				readyJump = false;
				jumpTimer = jumpTime;
				hasJumped = true;
			}
		}


		void ScaleCapsuleForCrouching(bool crouch)
		{
			if (m_IsGrounded && crouch)
			{
				if (m_Crouching) return;
				m_Capsule.height = m_Capsule.height / 2f;
				m_Capsule.center = m_Capsule.center / 2f;
				m_Crouching = true;
			}
			else
			{
				Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
				float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
				if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
				{
					m_Crouching = true;
					return;
				}
				m_Capsule.height = m_CapsuleHeight;
				m_Capsule.center = m_CapsuleCenter;
				m_Crouching = false;
			}
		}

		void PreventStandingInLowHeadroom()
		{
			// prevent standing up in crouch-only zones
			if (!m_Crouching)
			{
				Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
				float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
				if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
				{
					m_Crouching = true;
				}
			}
		}

		void HandleAirborneMovement()
		{
			// apply extra gravity from multiplier:
			Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
			m_Rigidbody.AddForce(extraGravityForce);

			m_GroundCheckDistance = m_Rigidbody.velocity.y < 1f ? m_OrigGroundCheckDistance : 0.01f;
		}


		void HandleGroundedMovement(bool jump)
		{
			// check whether conditions are right to allow a jump:
			if (jump && m_IsGrounded)
			{
				// jump!
				//m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower, m_Rigidbody.velocity.z);
				m_IsGrounded = false;
				m_GroundCheckDistance = 0.1f;
				readyJump = true;
				print("Jump");
			}
		}

		void ApplyExtraTurnRotation()
		{
			// help the character turn faster (this is in addition to root rotation in the animation)
			float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
			transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
		}

		private int WallCheck(){
			RaycastHit hitInfo;
			int layerMask = 1 << 2;
			layerMask = ~layerMask;
			int isNotOnWall = 1;

			if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), transform.forward, out hitInfo, 0.5f, layerMask, QueryTriggerInteraction.Ignore) && !m_IsGrounded){
				print("boi");
				isNotOnWall = 0;
			}
			return isNotOnWall;
		}
		void CheckGroundStatus()
		{
			int layerMask = 1 << 2;
			layerMask = ~layerMask;
			viewLayerMask = layerMask;

			RaycastHit hitInfo;
#if UNITY_EDITOR
			// helper to visualise the ground check ray in the scene view
			Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
#endif
			// 0.1f is a small offset to start the ray from inside the character
			// it is also good to note that the transform position in the sample assets is at the base of the character
			if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance, layerMask, QueryTriggerInteraction.Ignore))
			{
				m_GroundNormal = hitInfo.normal;
				m_IsGrounded = true;
			}
			else
			{
				m_IsGrounded = false;
				m_GroundNormal = Vector3.up;
			}
		}
		void FlipJumpSwitches(){
			if (jumpSwitches.Length > 0 && jumpSwitches.Any(s=>!s.flip))
			{
				onJumpSwitchToggled.Invoke();
			}
			for (int i = 0; i < jumpSwitches.Length; i++)
			{
				jumpSwitches[i].flip = true;
			}
		}
		// Step up stuff \/\/\/
		void FixedUpdate()
		{
			/*
			print("hi");
			Vector3 velocity = velocityStore;
			
			//Filter through the ContactPoints to see if we're grounded and to see if we can step up
			ContactPoint groundCP = default(ContactPoint);
			bool grounded = FindGround(out groundCP, allCPs);
			
			Vector3 stepUpOffset = default(Vector3);
			bool stepUp = false;
			if(grounded){
				stepUp = FindStep(out stepUpOffset, allCPs, groundCP, velocity);
			}
			
			//Steps
			if(stepUp)
			{
				playerModel.transform.parent = transform.parent;
				preStepUp = playerModel.transform.localPosition;
				stepUpTimer = 0;
				print("stepup");

				this.GetComponent<Rigidbody>().position += stepUpOffset;
				this.GetComponent<Rigidbody>().velocity = lastVelocity;
				testStepUp.transform.position = this.GetComponent<Rigidbody>().position;
			}
			
			allCPs.Clear();
			lastVelocity = velocity;
			*/
		}
	
		void OnCollisionEnter(Collision col)
		{
			allCPs.AddRange(col.contacts);
		}
	
		void OnCollisionStay(Collision col)
		{
			allCPs.AddRange(col.contacts);
		}
		
		/// Finds the MOST grounded (flattest y component) ContactPoint
		/// \param allCPs List to search
		/// \param groundCP The contact point with the ground
		/// \return If grounded
		bool FindGround(out ContactPoint groundCP, List<ContactPoint> allCPs)
		{
			groundCP = default(ContactPoint);
			bool found = false;
			foreach(ContactPoint cp in allCPs)
			{   
				//Pointing with some up direction
				if(cp.normal.y > 0.0001f && (found == false || cp.normal.y > groundCP.normal.y))
				{
					groundCP = cp;
					found = true;
				}
			}
			
			return found;
		}
		
		/// Find the first step up point if we hit a step
		/// \param allCPs List to search
		/// \param stepUpOffset A Vector3 of the offset of the player to step up the step
		/// \return If we found a step
		bool FindStep(out Vector3 stepUpOffset, List<ContactPoint> allCPs, ContactPoint groundCP, Vector3 currVelocity)
		{
			stepUpOffset = default(Vector3);
			
			//No chance to step if the player is not moving
			Vector2 velocityXZ = new Vector2(currVelocity.x, currVelocity.z);
			if(velocityXZ.sqrMagnitude < 0.0001f){
				return false;
			}
			
			foreach(ContactPoint cp in allCPs)
			{
				bool test = ResolveStepUp(out stepUpOffset, cp, groundCP);
				if(test)
					return test;
			}
			return false;
		}
		
		/// Takes a contact point that looks as though it's the side face of a step and sees if we can climb it
		/// \param stepTestCP ContactPoint to check.
		/// \param groundCP ContactPoint on the ground.
		/// \param stepUpOffset The offset from the stepTestCP.point to the stepUpPoint (to add to the player's position so they're now on the step)
		/// \return If the passed ContactPoint was a step
		bool ResolveStepUp(out Vector3 stepUpOffset, ContactPoint stepTestCP, ContactPoint groundCP)
		{
			stepUpOffset = default(Vector3);
			Collider stepCol = stepTestCP.otherCollider;
			
			//( 1 ) Check if the contact point normal matches that of a step (y close to 0)
			if(Mathf.Abs(stepTestCP.normal.y) >= 0.01f)
			{
				return false;
			}
			
			//( 2 ) Make sure the contact point is low enough to be a step
			if( !(stepTestCP.point.y - groundCP.point.y < maxStepHeight) )
			{
				return false;
			}
			
			//( 3 ) Check to see if there's actually a place to step in front of us
			//Fires one Raycast
			RaycastHit hitInfo;
			float stepHeight = groundCP.point.y + maxStepHeight + 0.0001f;
			Vector3 stepTestInvDir = new Vector3(-stepTestCP.normal.x, 0, -stepTestCP.normal.z).normalized;
			Vector3 origin = new Vector3(stepTestCP.point.x, stepHeight, stepTestCP.point.z) + (stepTestInvDir * stepSearchOvershoot);
			Vector3 direction = Vector3.down;
			if( !(stepCol.Raycast(new Ray(origin, direction), out hitInfo, maxStepHeight)) )
			{
				return false;
			}
			
			//We have enough info to calculate the points
			Vector3 stepUpPoint = new Vector3(stepTestCP.point.x, hitInfo.point.y+0.0001f, stepTestCP.point.z) + (stepTestInvDir * stepSearchOvershoot);
			Vector3 stepUpPointOffset = stepUpPoint - new Vector3(stepTestCP.point.x, groundCP.point.y, stepTestCP.point.z);
			
			//We passed all the checks! Calculate and return the point!
			stepUpOffset = stepUpPointOffset;
			return true;
		}
		public void DisableFloating(){
			this.GetComponent<ConstantForce>().enabled = true;
			m_Rigidbody.useGravity = true;
			floating = false;
			floatactive = false;
			floatOnce = false;
			playerHead.parent = headParent;
			headParent.parent = transform;
			headParent.localPosition = playerModelOffset;
			playerHead.localPosition = headOffset;
			headParent.localEulerAngles = playerModelRot;
			headParent.gameObject.SetActive(true);
		}
	}
}