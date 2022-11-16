using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LerpFromAtoB : MonoBehaviour
{
    [SerializeField] private UnityEvent onDoorStartedMoving;

    public Transform objectToMove;
    public GameObject destinationCam;

    [Header("Moves from current pos to End Pos")]
    public Vector3 endPos;

    [Header("Use End Pos x, y and/or z")] public bool x;
    public bool y = true, z;
    public Vector3 startPos;
    public float lerpTime = 5;
    private float timer = -1f;
    public bool activate;
    private GameObject player;


    private void Start()
    {
        startPos = objectToMove.localPosition;
        endPos = new Vector3(!x ? startPos.x : endPos.x, !y ? startPos.y : endPos.y, !z ? startPos.z : endPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (activate && timer < lerpTime)
        {
            objectToMove.localPosition = Vector3.Slerp(startPos, endPos, timer);
            timer += Time.deltaTime / lerpTime;

            if (timer > 0f && timer < 0.1f)
            {
                onDoorStartedMoving?.Invoke();
                Debug.Log("Should play sound");
            }

            if (timer > -0.9f && timer < 0f)
            {
                destinationCam.SetActive(true);
                player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().active = false;
            }

            if (timer > 1)
            {
                destinationCam.SetActive(false);
                player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().active = true;
            }
        }
    }
}