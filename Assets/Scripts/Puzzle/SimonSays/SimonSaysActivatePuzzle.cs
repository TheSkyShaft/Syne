using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysActivatePuzzle : MonoBehaviour
{
    private bool inTrigger;
    public GameObject activationArea;
    private SimonSays simonSays;
    private bool once;
    // Start is called before the first frame update
    void Start()
    {
        simonSays = transform.parent.parent.GetComponent<SimonSays>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && inTrigger){
            if(!once){
                activationArea.SetActive(true);
            }
            once = true;
            simonSays.Invoke("ShowColors", 3f);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            inTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            inTrigger = false;
        }
    }
}
