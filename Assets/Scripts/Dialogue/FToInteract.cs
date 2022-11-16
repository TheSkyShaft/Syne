using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FToInteract : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onPressedF;
    
    private GameObject fToInteract;
    [HideInInspector]
    public bool inside;
    // Start is called before the first frame update
    void Start()
    {
        fToInteract = GameObject.Find("FToInteract");
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)){
            onPressedF.Invoke();
            fToInteract.GetComponent<Text>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
            fToInteract.GetComponent<Text>().enabled = true;
            inside = true;
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player")
            fToInteract.GetComponent<Text>().enabled = false;
            inside = false;
    }
}
