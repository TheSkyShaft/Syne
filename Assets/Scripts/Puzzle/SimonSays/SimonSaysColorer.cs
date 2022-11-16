using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysColorer : MonoBehaviour
{
    public Color activeColor = new Color(0,0,0,1), inActiveColor = new Color(1,1,1,1), failColor = new Color(0.3f,0.3f,0.3f,1f);
    private float timer;
    public bool activateColor;
    private Material objectMat;
    private bool canActivate, isInTrigger;
    [Tooltip("How much to multiply one second by")]
    public float timerMultiplier = 2;
    public bool fail;
    public AudioClip playSound;
    // Start is called before the first frame update
    void Start()
    {
        objectMat = transform.GetChild(0).GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canActivate){
            transform.parent.GetComponent<SimonSays>().Receiver(transform.GetSiblingIndex());
        }
        if(activateColor){
            timer += Time.deltaTime * timerMultiplier;
            objectMat.color = Color.Lerp(activeColor, inActiveColor, timer);
            transform.GetChild(0).localScale = Vector3.Lerp(new Vector3(253f,253f,253f), new Vector3(280f, 280f, 280f), (Mathf.Sin(timer * 4) + 1) / 2);
            if(timer >= 1){
                if(isInTrigger){
                    canActivate = true;
                }else{
                    canActivate = false;
                }
                activateColor = false;
                timer = 0;
            }
        }else if(fail){
            timer += Time.deltaTime * timerMultiplier * 2;
            objectMat.color = Color.Lerp(failColor, inActiveColor, timer);
            if(timer >= 1){
                if(isInTrigger){
                    canActivate = true;
                }else{
                    canActivate = false;
                }
                fail = false;
                timer = 0;
            }
        }
    }
    public void TriggerColor(){
        activateColor = true;
        canActivate = false;
        AudioSource aud = transform.parent.GetComponent<AudioSource>();
        aud.clip = playSound;
        aud.Play();

    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            canActivate = true;
            isInTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            canActivate = false;
            isInTrigger = false;
        }
    }
}
