using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public DialogueContainer dialogueContainer = new DialogueContainer();
    private Text output, overlay, charName;
    public int dialogueId, dialogueProgress;
    public int dialogueLength = 99;
    private GameObject lastTrigger, player, lastDestinationCam, currentDestinationCam;
    public GameObject activateWhenDone;
    // Start is called before the first frame update
    void Awake()
    {
        output = transform.GetChild(0).gameObject.GetComponent<Text>();
        overlay = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Text>();
        charName = transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>();
        output.fontSize = overlay.fontSize;
        dialogueLength = 99;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            UpdateConversation();
        }
    }
    public void UpdateConversation(){
        if(dialogueProgress >= dialogueLength){
            EndConversation();
        }else{
            List<string> lines = dialogueContainer.dialogueTrees[dialogueId].dialogueTexts[dialogueProgress].textLines;
            if(lines.Count == 0){
                dialogueProgress++;
                lines = dialogueContainer.dialogueTrees[dialogueId].dialogueTexts[dialogueProgress].textLines;
            }

            dialogueLength = dialogueContainer.dialogueTrees[dialogueId].dialogueTexts.Count;
            output.text = "\n";
            for (int i = 0; i < lines.Count; i++){
                output.text += lines[i] + "\n";
            }

            overlay.text = output.text;
            charName.text = dialogueContainer.dialogueTrees[dialogueId].dialogueTexts[dialogueProgress].speakerName;
            charName.color = dialogueContainer.dialogueTrees[dialogueId].dialogueTexts[dialogueProgress].speakerColor;

            if(currentDestinationCam != null){  // Deactivates last destination cam if there is any
                currentDestinationCam.SetActive(false);
            }
            if(dialogueContainer.dialogueTrees[dialogueId].dialogueTexts[dialogueProgress].destinationCam != null){ // If theres a destination cam, activate it
                currentDestinationCam = dialogueContainer.dialogueTrees[dialogueId].dialogueTexts[dialogueProgress].destinationCam;
                currentDestinationCam.SetActive(true);
            }
            
            dialogueProgress++;
            player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().active = false;
            }
    }
    void EndConversation(){
        if(dialogueId == 2){
            player.GetComponent<Animator>().enabled = true;
            player.GetComponent<Animator>().SetTrigger("TriggerLibraryPortal");
            gameObject.SetActive(false);
        }else{
            if(currentDestinationCam != null){
                Invoke("DelayedDestinationCamDeactivation", 1f);
            }
            dialogueProgress = 0;
            lastTrigger.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.SetActive(false);
            if(dialogueContainer.dialogueTrees[dialogueId].objectToActivate != null){
                dialogueContainer.dialogueTrees[dialogueId].objectToActivate.SetActive(true);
            }
            if(activateWhenDone != null){
                activateWhenDone.SetActive(true);
            }
        }
    }
    public void ParseTrigger(GameObject trigger){
        lastTrigger = trigger;
    }
    void DelayedDestinationCamDeactivation(){
        player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().active = true;
        currentDestinationCam.SetActive(false);
    }
}
[System.Serializable]
public class DialogueText
{
    public string name;
    public string speakerName;
    public Color speakerColor;
    public List<string> textLines;
    public GameObject destinationCam;
}
[System.Serializable]
public class DialogueTree
{
    public string name;
    public List<DialogueText> dialogueTexts;
    public GameObject objectToActivate;
}
 
[System.Serializable]
public class DialogueContainer
{
    public List<DialogueTree> dialogueTrees;
}
