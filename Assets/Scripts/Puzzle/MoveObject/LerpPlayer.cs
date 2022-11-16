using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPlayer : MonoBehaviour
{
    public bool lerpPlayer;
    public Transform startPos, endPos;
    private Transform player;
    private float timer;
    public float lerpTime = 3f, sinTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(lerpPlayer){
            if(timer < 1f){
                timer += Time.deltaTime / lerpTime;
                player.position = Vector3.Lerp(startPos.position, endPos.position, timer) + new Vector3(0, Mathf.Sin(timer * 3.1385f) * (Vector3.Distance(startPos.position, endPos.position) / 4), 0);
            }else{
                timer = 0;
                lerpPlayer = false;
                player.GetComponent<ConstantForce>().enabled = true;
                player.GetComponent<Rigidbody>().useGravity = true;
                player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            lerpPlayer = true;
            player.GetComponent<ConstantForce>().enabled = false;
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
