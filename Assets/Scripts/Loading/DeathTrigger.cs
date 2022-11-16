using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private RespawnManager respawnManager;
    private void Start() {
        respawnManager = GameObject.FindGameObjectWithTag("KillManager").GetComponent<RespawnManager>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            respawnManager.ResetPlayer();
        }
    }
}
