using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    public List<GameObject> indicators; // indicators should be listed in order in the inspector depending on color, following the r g b y p o m scheme
    [Tooltip("Each multiplicative of 10 adds a new sequence, I.E: 13 would be two rounds, first round would only light up green, next round would light up green and then yellow")]
    public string toSolve = "0";
    [Tooltip("Must be longer than the color time on the buttons")]
    public float displayDelay = 1.01f;
    public float completeCycleDelay = 3f;
    public int currentCycle = 0;
    private float timer, freezeTimer, freezeSolve;
    public bool activate;
    public int timesDisplayed;
    public List<int> displayOrder;
    private int numberSolved;
    public AudioClip complete, fail;
    public GameObject camActivationArea, destinationCam, noteToActivate;
    public DetectionNull detectionNull;
    private bool endSound, won;
    private SImonSaysKeyAnimator sSKA;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            indicators.Add(transform.GetChild(i + 1).gameObject);
        }
        GetDisplayOrder();
        sSKA = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<SImonSaysKeyAnimator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(activate && currentCycle < toSolve.Length){
            ShowColors();
            activate = false;
        }
    }
    void GetDisplayOrder(){
        for (int i = 0; i < toSolve.Length; i++)
        {
            displayOrder.Add(System.Convert.ToInt32(toSolve[i] - 48)); // -48 is to account for how the alphabet converts numbers, a b c etc are 0 1 2 while the actual numbers are 48 behind.
        }
    }
    public void ShowColors(){
        freezeSolve = displayDelay * (currentCycle + 1);
        freezeTimer = Time.time;
        if(IsInvoking("FlashColors")){
            CancelInvoke("FlashColors");
        }
        InvokeRepeating("FlashColors", 0, displayDelay);

    }
    void FlashColors(){
        indicators[displayOrder[timesDisplayed]].GetComponent<SimonSaysColorer>().TriggerColor();
        print("hi");
        timesDisplayed++;
        if(timesDisplayed > currentCycle){
            timesDisplayed = 0;
            CancelInvoke("FlashColors");
        }
        if(timesDisplayed >= displayOrder.Count){
            timesDisplayed = 0;
        }
        if(endSound){
            gameObject.GetComponent<AudioSource>().enabled = false;
        }
    }
    public void Receiver(int received){
        if(Time.time > freezeTimer + freezeSolve && !won){
            received--;
            if(received == displayOrder[numberSolved]){
                // win
                indicators[received].GetComponent<SimonSaysColorer>().TriggerColor();
                Correct();
            }else{
                // fail
                ResetPuzzle();
            }
        }
    }
    void Correct(){
        print("Correct");
        numberSolved++;
        if(currentCycle < numberSolved){
            EndCycle();
        }
    }
    void EndCycle(){
        print("cycleComplete");
        currentCycle++;
        numberSolved = 0;
        if(currentCycle >= toSolve.Length){
            Win();
        }else{
            Invoke("ShowColors", completeCycleDelay);
        }
        sSKA.LowerKey();
    }
    void Win(){
        player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().active = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        AudioSource aud = gameObject.GetComponent<AudioSource>();
        aud.clip = complete;
        aud.Play();
        print("win");
        won = true;
        Invoke("ShowDestination", completeCycleDelay);
        Invoke("ShowNote", completeCycleDelay - 0.2f);
    }
    void ShowNote(){
        if(noteToActivate != null){
            noteToActivate.SetActive(true);
        }
    }
    void ShowDestination(){
        endSound = true;
        ShowColors();
        camActivationArea.SetActive(false);
        detectionNull.enable = true;
        destinationCam.SetActive(true);
        Invoke("DeactivateCamera", completeCycleDelay);
        
    }
    void ResetPuzzle(){
        currentCycle = 0;
        numberSolved = 0;
        for (int i = 0; i < indicators.Count; i++)
        {
            indicators[i].GetComponent<SimonSaysColorer>().fail = true;
        }
        freezeSolve = completeCycleDelay;
        freezeTimer = Time.time;
        Invoke("ShowColors", completeCycleDelay);

        AudioSource aud = gameObject.GetComponent<AudioSource>();
        aud.clip = fail;
        aud.Play();

        sSKA.ResetKey();
    }
    void DeactivateCamera(){
        destinationCam.SetActive(false);
        player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().active = true;
    }
}
