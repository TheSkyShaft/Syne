using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RespawnManager : MonoBehaviour
{
    public UnityEvent onRespawn;
    [HideInInspector]
    public GameObject player;
    public GameObject respawnPointEffect, secondaryRespawnPointEffect;
    [HideInInspector]
    public Vector3 respawnPoint;
    private Vector3 checkPoint; // Checks if respawn point has changed
    public float killHeight = -1f;
    private float timer, deathTimer;
    private GameObject butterflyHolder; 
    private Transform playerHeadParent;
    public GameObject playerHead;
    private Vector3 deathPoint, headOffset;
    private bool thePlayerIsKill, itsRewindTime;

    public bool deathAnimation = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawnPoint = player.transform.position;
        checkPoint = respawnPoint;
        if(playerHead != null){
            playerHeadParent = playerHead.transform.parent;
            headOffset = playerHead.transform.localPosition;
        }else{
            deathAnimation = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.transform.position.y < killHeight && !thePlayerIsKill){
            onRespawn.Invoke();

            if(deathAnimation){
                thePlayerIsKill = true;
                ThePlayerIsDead();
                //Invoke("ThePlayerIsDead", 1f);
            }else{
                ResetPlayer();
            }
        }
        if(Input.GetKey(KeyCode.Escape)){
            timer += Time.deltaTime;
        }else{
            timer = 0;
        }
        if(timer > 3){
            Application.Quit();
        }

        if(itsRewindTime){
            deathTimer += Time.deltaTime * 0.33f;
            playerHead.transform.position = Vector3.Slerp(deathPoint, respawnPoint + headOffset, deathTimer);
            if(deathTimer > 1){
                player.transform.position = respawnPoint;
                player.SetActive(true);
                playerHead.transform.parent = playerHeadParent;
                playerHead.transform.localPosition = headOffset;

                itsRewindTime = false;
                thePlayerIsKill = false;
                deathTimer = 0;
            }
        }
    }
    private void Update() {
        if(respawnPoint != checkPoint){
            if(butterflyHolder != null){
                Destroy(butterflyHolder);
            }
            if(respawnPointEffect != null){
                butterflyHolder = Instantiate(respawnPointEffect, respawnPoint, Quaternion.identity);
            }
            if(secondaryRespawnPointEffect != null){
                Instantiate(secondaryRespawnPointEffect, respawnPoint, Quaternion.identity);
            }
        }
        checkPoint = respawnPoint;
    }
    void ThePlayerIsDead(){ // Yes, i am dead. Why is the player dead? I dunno. I think it wa... *SHUSH* You are dead! Ok! *Deadening noises*
        Time.timeScale = 1;
        deathPoint = player.transform.position;
        itsRewindTime = true;
        playerHead.transform.parent = transform;
        player.SetActive(false);
    }
    public void ResetPlayer(){
        player.transform.position = respawnPoint;
    }
}
