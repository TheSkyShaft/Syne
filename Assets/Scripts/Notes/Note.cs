using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int noteID;
    public float speedModifier = 1, rotationSpeed = 90;
    private float timer, moveDownTimer;
    [HideInInspector]
    public NoteManager noteManager;
    public Vector3 topPos = new Vector3(0,0.5f,0),botPos = new Vector3(0,0,0);
    private Transform note;
    [Header("Used with the puzzle ball to lower note when complete")]
    public bool moveDownWhenColliderEnabled;
    public Vector3 moveDownAmount = new Vector3(0,-5, 0);
    private Vector3 startPos;
    private bool active, dissolve;
    private Material noteMat;
    private bool lockNoteTime;
    // Start is called before the first frame update
    void Start()
    {
        noteManager = GameObject.FindGameObjectWithTag("NoteManager").GetComponent<NoteManager>();
        note = transform.GetChild(0);
        startPos = transform.localPosition;
        noteMat = transform.GetChild(0).GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        note.localPosition = Vector3.Lerp(botPos, topPos, (Mathf.Sin(timer * speedModifier) + 1) / 2);
        timer += Time.deltaTime;
        if(moveDownWhenColliderEnabled){
            if(GetComponent<Collider>().enabled){
                transform.localPosition = Vector3.Lerp(startPos, moveDownAmount + startPos, moveDownTimer);
                moveDownTimer += Time.deltaTime;
            }
        }
        if(active && !dissolve){
            if(Time.timeScale > 0 && !lockNoteTime){
                Time.timeScale -= Time.fixedDeltaTime / 1.5f;
                
            }else{
                lockNoteTime = true;
            }
            if(lockNoteTime){
                Time.timeScale = 0;
            }
            if(Input.GetKeyDown(KeyCode.F)){
                dissolve = true;
                Time.timeScale = 1f;
            }
        }else if(dissolve){
            float prog = noteMat.GetFloat("_Level");
            noteMat.SetFloat("_Level", prog + (Time.deltaTime * 0.2f));
            if(prog > 1){
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter(Collider other){
        if(!dissolve){
            noteManager.NewNote(noteID);
            active = true;
        }
    }
}
