using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    public PointList NoteList = new PointList();
    public List<bool> unlockedNotes;
    public Text noteCanvas;
    public int selectedNote;
    public string unlockedNotesEncrypted;
    private float pickedUpNoteTimer = -0.2f, showcaseNoteTimer;
    public float pickedUpNoteDisplayTime = 5f, pickedUpNoteTransitionTime = 0.2f;
    public Vector3 pickUpShowPos;
    private Vector3 pickUpHidePos;
    public Transform pickedUpNoteShowcase;
    public Image progress;
    public bool pickedUpNote;

    void Start(){
        transform.GetChild(0).gameObject.SetActive(false);
        int noteListLength = NoteList.notes.Count;
        print(noteListLength);
        unlockedNotes = new List<bool>();
        for (int i = 0; i < noteListLength; i++)
        {
            unlockedNotes.Add(false);
        }
        ResetUnlockedNotes();
        string noteStore = PlayerPrefs.GetString("UnlockedNotes");
        if(noteStore.Length < noteListLength + 1){
           noteStore = Mathf.RoundToInt(Mathf.Pow(10, noteListLength)).ToString();
           PlayerPrefs.SetString("UnlockedNotes", noteStore);
        }
        unlockedNotesEncrypted = noteStore;
        
        for (int i = 0; i < noteListLength; i++)
        {
            print(noteListLength + " " + noteStore);
            string s = noteStore.Substring(noteListLength - i,1);
            if(s == "1"){
                unlockedNotes[i] = true;
            }
        }
        PlayerPrefs.Save();
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.F)){
            noteCanvas.transform.parent.gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            ResetUnlockedNotes();
        }

        if(pickedUpNote){
            if(pickedUpNoteTimer < 0){
                showcaseNoteTimer += Time.deltaTime / pickedUpNoteTransitionTime;
                pickedUpNoteShowcase.position = Vector3.Lerp(pickUpHidePos, pickUpShowPos, showcaseNoteTimer);
            }else{
                if(pickedUpNoteTimer < pickedUpNoteDisplayTime){
                    showcaseNoteTimer = 0;
                }
            }
            if(pickedUpNoteTimer > pickedUpNoteDisplayTime){
                showcaseNoteTimer += Time.deltaTime / pickedUpNoteTransitionTime;
                pickedUpNoteShowcase.position = Vector3.Lerp(pickUpShowPos, pickUpHidePos, showcaseNoteTimer);
            }
            pickedUpNoteTimer += Time.deltaTime;

            if(showcaseNoteTimer > 1 && pickedUpNoteTimer > pickedUpNoteDisplayTime){
                pickedUpNoteTimer = 0.2f;
            }
        }
    }
    public int NewNote(int noteId){
        noteCanvas.transform.parent.gameObject.SetActive(true);
        unlockedNotes[noteId] = true;
        selectedNote = noteId;
        
        string noteStore = PlayerPrefs.GetString("UnlockedNotes");

        // B R O K E N, M U S T C O N V E R T T O S T R I N G
        /*
        string s = noteStore.ToString().Substring(NoteList.notes.Count - noteId,1);
        if(s == "0"){
            noteStore += Mathf.RoundToInt(Mathf.Pow(10, noteId));
            PlayerPrefs.SetInt("UnlockedNotes", noteStore);
            PlayerPrefs.Save();
        }
            */

        print(selectedNote);
        ShowNote();
        return 0;
    }
    public void ShowNote(){
        noteCanvas.text = "";
        List<string> noteText = NoteList.notes[selectedNote].noteLine;
        for (int i = 0; i < noteText.Count; i++)
        {
            noteCanvas.text += noteText[i] + "\n";
        }
        noteCanvas.transform.parent.gameObject.SetActive(true);
    }
    public void ResetUnlockedNotes(){
        string s = "1";
        for (int i = 0; i < NoteList.notes.Count; i++)
        {
            s += "0";
        }
        PlayerPrefs.SetString("UnlockedNotes", s);
    }
}

[System.Serializable]
public class Point
{
    public string name;
    public List<string> noteLine;
}
 
[System.Serializable]
public class PointList
{
    public List<Point> notes;
}
