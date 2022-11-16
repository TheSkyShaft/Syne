using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableMove : MonoBehaviour
{
    public bool move;
    public Transform endTrans;
    private Vector3 startPos, endPos;
    private float timer;
    public float moveTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        if(endTrans == null){
            endTrans = transform.GetChild(0);
        }
        endPos = endTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(move){
            timer += Time.deltaTime / moveTime;
            transform.position = Vector3.Lerp(startPos, endPos, timer);
            if(timer > 1) move = !move; 
        }
    }
}
