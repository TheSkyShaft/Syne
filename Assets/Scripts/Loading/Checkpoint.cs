using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public RespawnManager manager;
    public Vector3 respawnOffset = new Vector3(0,1,0);
    
    void Start(){
        manager = GameObject.FindGameObjectWithTag("KillManager").GetComponent<RespawnManager>();
    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            manager.respawnPoint = transform.position + respawnOffset;
        }
    }
}
