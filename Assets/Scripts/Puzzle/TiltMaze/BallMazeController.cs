using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMazeController : MonoBehaviour
{
    public bool active;
    public float ballVelocity;
    public Rigidbody ballRigidbody;
    private float timer;
    public bool flip;
    private int flipDir = 1;
    private Vector3 mazeRot;
    public float flipAmount = 90;
    private bool done;
    public List<OnEnableMove> stuffToEnable;
    public GameObject destinationCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            ballVelocity = ballRigidbody.velocity.y;

            if(Input.GetKeyDown(KeyCode.A) && !flip && !done){
                FlipPrep(1);
            }
            if(Input.GetKeyDown(KeyCode.D) && !flip && !done){
                FlipPrep(-1);
            }
            if(flip){
                timer += Time.deltaTime;
                transform.rotation = Quaternion.Lerp(Quaternion.Euler(mazeRot), Quaternion.Euler(mazeRot + new Vector3(0,0,flipAmount * flipDir)), timer);
                if(timer > 1 && ballVelocity > -0.1f){
                    flip = false;
                    timer = 0;
                }
            }
        }
    }
    void FlipPrep(int flipDirection){
        flip = true;
        flipDir = flipDirection;
        mazeRot = transform.eulerAngles;
    }
    public void Finished(){
        done = true;
        foreach (OnEnableMove item in stuffToEnable)
        {
            item.move = true;
        }
        gameObject.GetComponent<ActivationArea>().ToggleEnable();
        if(destinationCamera != null){
                ToggleDestinationCamera();
                Invoke("ToggleDestinationCamera", 4.5f);
            }
    }
    void ToggleDestinationCamera(){
        destinationCamera.SetActive(!destinationCamera.activeSelf);
    }
}
