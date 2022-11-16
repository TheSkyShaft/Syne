using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Transform playerParent;
    // Start is called before the first frame update
    void Start()
    {
        playerParent = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            other.transform.parent = playerParent;
        }
    }
}
