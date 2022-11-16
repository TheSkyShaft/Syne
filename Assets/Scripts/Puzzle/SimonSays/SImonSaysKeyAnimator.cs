using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SImonSaysKeyAnimator : MonoBehaviour
{
    public int stage = 2;
    public float lowerAmount = 0.4f;
    private Vector3 oldPos, orgPos;
    private bool lower, rotate, reset;
    private float timer;
    private int orgStage;

    // Start is called before the first frame update
    void Start()
    {
        oldPos = orgPos = transform.position;
        orgStage = stage;
    }

    // Update is called once per frame
    void Update()
    {
        if(!reset){
            if(lower){
                timer += Time.deltaTime;
                transform.position = Vector3.Lerp(oldPos, oldPos - new Vector3(0,lowerAmount,0), timer);
                if(timer > 1){
                    timer = 0;
                    lower = false;
                }
            } 
        }else{
                timer += Time.deltaTime;
                transform.position = Vector3.Lerp(oldPos, orgPos, timer);
                if(timer > 1){
                    timer = 0;
                    reset = false;
                }
        }
        if(rotate){
            timer += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(-90,0,0), Quaternion.Euler(-90,90,0), timer);
        }
    }
    public void LowerKey(){
        if(stage > 0){
            stage--;
            oldPos = transform.position;
            lower = true;
        }else{
            // Downs
            if(!rotate){
                stage--;
                oldPos = transform.position;
                lower = true;   
            }
            rotate = true;
        }
    }
    public void ResetKey(){
        stage = orgStage;
        reset = true;
    }
}
