using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysCameraArea : MonoBehaviour
{
    private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter(Collider other) {
        cam.SetActive(true);
    }
    private void OnTriggerExit(Collider other) {
        cam.SetActive(false);
    }
}
