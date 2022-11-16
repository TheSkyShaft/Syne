using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCameraOnTriggerEnter : MonoBehaviour
{
    public GameObject cameraToActivate;
    public bool dontDisable;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            cameraToActivate.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player" && !dontDisable){
            cameraToActivate.SetActive(false);
        }
    }
}
