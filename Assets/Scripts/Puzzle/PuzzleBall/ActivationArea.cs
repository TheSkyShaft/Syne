using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationArea : MonoBehaviour
{
    public GameObject puzzleCamera;
    private GameObject player;
    public bool inOrOut;
    public bool disabled;
    [Header("Only fill if you use a detection null")]
    public DetectionNull objectToActivate;
    [Header("Fill if using DetectionNull")]
    public GameObject destinationCam;
    private float timer = -1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && inOrOut && !disabled){
            ToggleEnable();
        }
        if(disabled){
            if(objectToActivate == null){
                gameObject.GetComponent<LerpFromAtoB>().activate = true;
            }else{
                objectToActivate.enable = true;
                if(timer > -0.9f && timer < 0f){
                    destinationCam.SetActive(true);
                }
                if(timer > 1){
                    destinationCam.SetActive(false);
                }
                timer += Time.deltaTime / 3;
            }
        }
    }
    public void ToggleEnable(){
        player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().active = !player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().active;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        puzzleCamera.SetActive(!puzzleCamera.activeSelf);
        if(gameObject.GetComponentInChildren<PuzzleBall>()){
            gameObject.GetComponentInChildren<PuzzleBall>().active = !gameObject.GetComponentInChildren<PuzzleBall>().active;
        }
        if(gameObject.GetComponent<BallMazeController>()){
            gameObject.GetComponent<BallMazeController>().active = !gameObject.GetComponent<BallMazeController>().active;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            inOrOut = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            inOrOut = false;
        }
    }
}
