using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatActivator : MonoBehaviour
{
    private GameObject player;
    public float upForce = 2000f;
    public float floatTime = 2f;
    private float floatTimer;
    private bool transport;
    private UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter playerController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transport){
            if(floatTimer < 1){
                floatTimer += Time.deltaTime / floatTime;
                player.transform.position = Vector3.Lerp(transform.position, transform.GetChild(0).position, floatTimer);
                player.GetComponent<ConstantForce>().enabled = false;
                player.GetComponent<Rigidbody>().useGravity = false;
            }else{
                transport = false;
                SetPlayerFloat();
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            transport = true;
            playerController.playerHead.parent = playerController.transform;
            playerController.headParent.parent = playerController.transform.parent;
            playerController.headParent.gameObject.SetActive(true);
        }
    }
    void SetPlayerFloat(){
        player.GetComponent<ConstantForce>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        floatTimer = 0;
        playerController.floating = true;
    }
}
