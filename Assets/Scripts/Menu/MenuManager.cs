using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private bool menuOpen;
    private GameObject mainMenu,noteMenu;
    private NoteManager noteMan;
    public List<GameObject> noteButtons;
    public List<NoteMenu> noteMenus;
    public Color highlightColor = new Color(1,1,1,1), nonHighlightColor = new Color(1,1,1,0.5f), disabledColor = new Color(1,1,1,0.25f);
    public Scrollbar scroller;
    public List<int> unlocked;
    public List<string> noteNames;
    public GameObject noteNameStorage;
    public Text noteText;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        mainMenu = transform.GetChild(0).GetChild(1).gameObject;
        noteMenu = transform.GetChild(0).GetChild(2).gameObject;
        noteMan = GameObject.FindGameObjectWithTag("NoteManager").GetComponent<NoteManager>();
        scroller.onValueChanged.AddListener((float val) => UpdateScrollbar(val));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !menuOpen){
            OpenMenu();
        }else if(Input.GetKeyDown(KeyCode.Escape) && menuOpen){
            Resume();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) && noteMenu.activeSelf){
            if(scroller.value < 1f){
                scroller.value += 1f / (noteNames.Count - 1f);
                print(1f / (noteNames.Count - 1f));
                print("down");
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && noteMenu.activeSelf){
            if(scroller.value > 0f){
            scroller.value -= 1f / (noteNames.Count - 1f);
            print("up");
            }
        }
    }
    public void OpenMenu(){
        Cursor.visible = true;
        Time.timeScale = 0;
        transform.GetChild(0).gameObject.SetActive(true);
        menuOpen = true;
    }
    public void ExitMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Resume(){
        Cursor.visible = false;
        Time.timeScale = 1f;
        transform.GetChild(0).gameObject.SetActive(false);
        menuOpen = false;
        mainMenu.SetActive(true);
        noteMenu.SetActive(false);
    }
    public void ViewNotes(){
        mainMenu.SetActive(false);
        noteMenu.SetActive(true);
        GetNotes();
    }
    void GetNotes(){
        string noteStore = PlayerPrefs.GetString("UnlockedNotes");
        noteNames = new List<string>();
        unlocked = new List<int>();
        for (int i = 0; i < noteStore.Length - 1; i++)
        {
            string s = noteStore.Substring((noteStore.ToString().Length - 1) - i,1);
            print(s);
            if(s == "0"){
                unlocked.Add(0);
                noteNames.Add("???");
            }else{
                unlocked.Add(1);
                noteNames.Add(noteMan.NoteList.notes[i].name);
            }
        }
        CreateChapterTitles();
    }
    void CreateChapterTitles(){
        for (int i = 0; i < noteNameStorage.transform.childCount - 1; i++)
        {
            Destroy(noteNameStorage.transform.GetChild(i + 1).gameObject);
        }
        GameObject textGameObject = noteNameStorage.transform.GetChild(0).gameObject;
        textGameObject.SetActive(true);
        for (int i = 0; i < noteNames.Count; i++)
        {
            GameObject text = Instantiate(textGameObject, textGameObject.transform.position + new Vector3(0,-100 * i,0), Quaternion.identity);
            text.transform.parent = noteNameStorage.transform;
            text.name = text.GetComponent<Text>().text = noteNames[i];
            text.transform.localScale = textGameObject.transform.localScale;
        }
        textGameObject.SetActive(false);
        scroller.numberOfSteps = noteNames.Count;
        UpdateScrollbar(0);
    }
    public void UpdateScrollbar(float value){
        noteNameStorage.transform.localPosition = new Vector3(0, 100 * (value * (noteNames.Count - 1)), 0);
        noteText.text = "";
        string noteStore = PlayerPrefs.GetString("UnlockedNotes");

        string s = noteStore.Substring((noteStore.Length - 1) - Mathf.FloorToInt(value * (noteNames.Count - 1)),1);
        print(s);
        if(s == "0"){
            noteText.text = "Note not found" + "\nHint: " + noteMan.NoteList.notes[Mathf.FloorToInt(value * (noteNames.Count - 1))].name;
        }else{
            for (int i = 0; i < noteMan.NoteList.notes[Mathf.FloorToInt(value * (noteNames.Count - 1))].noteLine.Count; i++)
            {
                noteText.text += noteMan.NoteList.notes[Mathf.FloorToInt(value * (noteNames.Count - 1))].noteLine[i] + "\n"; 
            }
        }
        print(value);
    }
}
[System.Serializable]
public class NoteMenu{
    public string menuChapter;
    public List<string> noteTitles;

}