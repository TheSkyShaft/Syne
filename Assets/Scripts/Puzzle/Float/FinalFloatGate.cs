using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFloatGate : MonoBehaviour
{
    public Transform returnPosition;
    public float returnTime = 3;
    private float returnTimer;
    private bool goHome;
    private Vector3 startPos;
    private GameObject player;
    public List<OnEnableMove> stuffToEnable;
    public GameObject destinationCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(goHome){
            goHome = false;
            player.transform.position = returnPosition.position;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            goHome = true;
            startPos = other.transform.position;
            player = other.gameObject;
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
    void ToggleDestinationCamera(){
        destinationCamera.SetActive(!destinationCamera.activeSelf);
    }
}
