using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerLocation : MonoBehaviour
{
    private void Awake() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        #if UNITY_EDITOR
        player.transform.position = transform.position + new Vector3(0,2,0);
        #endif
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
