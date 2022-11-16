using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivater : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public int dialogueId;
    public bool triggerActive;
    private int libraryActive, levelCompletion;
    private void Start() {
        for (int i = 0; i < 4; i++)
        {
            levelCompletion += PlayerPrefs.GetInt("Level" + i.ToString() + "Complete", 0);
        }
        dialogueId = libraryActive = levelCompletion;
    
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && triggerActive){
            Activate();
            triggerActive = false;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            triggerActive = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            triggerActive = false;
        }
    }
    void Activate(){
        dialogueId = libraryActive;
        dialogueManager.dialogueId = dialogueId;
        dialogueManager.gameObject.SetActive(true);
        //Activates camera
        transform.GetChild(0).gameObject.SetActive(true);
        dialogueManager.UpdateConversation();
        dialogueManager.ParseTrigger(gameObject);
        
    }
}
