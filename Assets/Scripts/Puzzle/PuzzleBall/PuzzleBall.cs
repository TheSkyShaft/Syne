using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleBall : MonoBehaviour
{
    public UnityEvent onComplete;
    public List<SphereLayers> sphereLayers;
    private Quaternion currentSphereVector;
    private Transform sphere;
    public int currentLayer;
    public float xModifier = 15, yModifier = 15, zModifier = 60, correctionSpeed = 25, snappingDegrees = 5;
    public float timer, dissolveTimer, dissolveTimer2 = 1.1f;
    private Quaternion snapTo, snapFrom;
    [HideInInspector]
    public bool active;
    public Material outerMat;
    public Vector3 solveRotation; 
    [Header("Use this to find vector")]
    public Vector3 testVec;
    private bool complete;
    private Transform puzzleBall;
    private Vector3 puzzleBallZero;
    private Camera worldCam;
    public float dissolveDelay = 12, dissolveTime = 3;
    private Material matToDissolve;
    public Collider activateTriggerWhenDone;

    private AudioSource audioSource;
    public List<OnEnableMove> stuffToEnable;
    [Header("Fill to let puzzle ball handle the destination camera")]
    public GameObject destinationCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        currentLayer = sphereLayers.Count - 1;
        snapFrom = snapTo = sphereLayers[currentLayer].sphere.transform.rotation;
        solveRotation = sphereLayers[currentLayer].solveRotation;
        puzzleBall = transform.parent;
        puzzleBallZero = puzzleBall.position;
        worldCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active ){
            float x = Input.GetAxis("Vertical");
            float y = -Input.GetAxis("Horizontal");
            float z = -Input.GetAxis("Debug Horizontal");

            sphere = sphereLayers[currentLayer].sphere.transform;
            currentSphereVector = sphere.rotation;

            testVec = currentSphereVector.eulerAngles;

            if(x > 0 || y > 0 || z > 0 || x < 0 || y < 0 || z < 0){
                if (!audioSource.isPlaying && !complete)
                {
                    audioSource.Play();
                }
                timer = -0.2f;
                snapFrom = currentSphereVector;
                snapTo = Quaternion.Euler((snapFrom.eulerAngles.x - ((snapFrom.eulerAngles.x + (snappingDegrees / 2)) % snappingDegrees)) + (snappingDegrees / 2),
                (snapFrom.eulerAngles.y - ((snapFrom.eulerAngles.y + (snappingDegrees / 2)) % snappingDegrees)) + (snappingDegrees / 2),
                (snapFrom.eulerAngles.z - ((snapFrom.eulerAngles.z + (snappingDegrees / 2)) % snappingDegrees)) + (snappingDegrees / 2));
            }else
            {
                audioSource.Pause();
                timer += Time.deltaTime;
                sphere.rotation = Quaternion.Lerp(snapFrom, snapTo, timer * correctionSpeed);
            }
            GetLocalRotation(y * yModifier * Time.deltaTime, x * xModifier * Time.deltaTime, z * zModifier * Time.deltaTime);
            //sphere.Rotate(new Vector3(x * xModifier * Time.deltaTime, y * yModifier * Time.deltaTime, z * zModifier * Time.deltaTime), Space.World);
            
            if((currentSphereVector.eulerAngles.x < (snappingDegrees / 4) + solveRotation.x &&
            currentSphereVector.eulerAngles.x > (-snappingDegrees / 4) + solveRotation.x &&
            currentSphereVector.eulerAngles.y < (snappingDegrees / 4) + solveRotation.y &&
            currentSphereVector.eulerAngles.y > (-snappingDegrees / 4) + solveRotation.y &&
            currentSphereVector.eulerAngles.z < (snappingDegrees / 4) + solveRotation.z &&
            currentSphereVector.eulerAngles.z > (-snappingDegrees / 4) + solveRotation.z) &&
            timer > 1 / correctionSpeed){
                print("Win");
                sphere.gameObject.SetActive(false);
                currentLayer--;
                sphereLayers[currentLayer].sphere.GetComponent<MeshRenderer>().material = outerMat;
                timer = -2;
                solveRotation = sphereLayers[currentLayer].solveRotation;
                
                if(currentLayer <= 0){
                    sphere = sphereLayers[currentLayer].sphere.transform;
                    active = false;
                    complete = true;
                    onComplete.Invoke();
                    Invoke("AADisabler", dissolveTime + 1);
                    foreach (OnEnableMove item in stuffToEnable)
                    {
                        item.move = true;
                    }
                    if(destinationCamera != null){
                        ToggleDestinationCamera();
                        Invoke("ToggleDestinationCamera", 4.5f);
                    }
                }
            }
        }
        if(complete){
            sphere.Rotate(new Vector3(15 * Time.deltaTime, 15 * Time.deltaTime, 15 * Time.deltaTime));
            puzzleBall.position = Vector3.Lerp(puzzleBallZero - new Vector3(0,-1,0), puzzleBallZero - new Vector3(0, 1, 0), (Mathf.Sin(Time.time) + 1) / 2);

            if(matToDissolve == null){
                matToDissolve = sphere.GetChild(0).GetComponent<MeshRenderer>().material;
            }
            dissolveTimer -= Time.deltaTime;
            if(-dissolveDelay > dissolveTimer){
                sphere.GetComponent<MeshRenderer>().material.color = new Color(1,1,1, Mathf.Lerp(0,1,dissolveTimer2));
                matToDissolve.SetFloat("_DissolveProg", dissolveTimer2);
                dissolveTimer2 -= Time.deltaTime / dissolveTime;
                if(activateTriggerWhenDone != null && dissolveTimer < -dissolveTime)
                    activateTriggerWhenDone.enabled = true;
                    gameObject.transform.parent.GetComponent<ActivationArea>().inOrOut = false;
                if(dissolveTimer2 < 0){
                    Destroy(transform.parent.gameObject, 15f);
                }
            }else{
                dissolveTimer2 = 1f;
            }
        }
    }
    void AADisabler(){
        ActivationArea aA = gameObject.transform.parent.GetComponent<ActivationArea>();
        aA.disabled = true;
        aA.ToggleEnable();
    }
    private void GetLocalRotation(float rotX, float rotY, float rotZ){
        float sensitivity = 0.25f;
         //Gets the world vector space for cameras up vector 
         Vector3 relativeUp = worldCam.transform.TransformDirection(Vector3.up);
         //Gets world vector for space cameras right vector
         Vector3 relativeRight = worldCam.transform.TransformDirection(Vector3.right);

         Vector3 relativeForward = worldCam.transform.TransformDirection(Vector3.forward);
 
         //Turns relativeUp vector from world to objects local space
         Vector3 objectRelativeUp = transform.InverseTransformDirection(relativeUp);
         //Turns relativeRight vector from world to object local space
         Vector3 objectRelaviveRight = transform.InverseTransformDirection(relativeRight);

         Vector3 objectRelaviveForward = transform.InverseTransformDirection(relativeForward);
         
         sphere.rotation = Quaternion.AngleAxis(rotX / gameObject.transform.localScale.x * sensitivity, objectRelativeUp)
             * Quaternion.AngleAxis(rotY / gameObject.transform.localScale.x  * sensitivity, objectRelaviveRight)
             * Quaternion.AngleAxis(rotZ / gameObject.transform.localScale.x  * sensitivity, objectRelaviveForward) * sphere.rotation;
    }
    void ToggleDestinationCamera(){
        destinationCamera.SetActive(!destinationCamera.activeSelf);
    }
}
[System.Serializable]
public class SphereLayers{
    public string name = "sphere";
    public GameObject sphere;
    public Vector3 solveRotation;
}

