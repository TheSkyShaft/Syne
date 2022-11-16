using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenTriggerLerp : MonoBehaviour
{
    public float moveTime = 3f;
    public bool isInTrigger;
    private float timer;
    private Transform player, playerParent;
    public List<ObjectsToLerp> thingsToMove;
    // Start is called before the first frame update
    void Start()
    {
        foreach (ObjectsToLerp item in thingsToMove)
        {
            item.startPos = item.objectToMove.transform.position;
            item.endPos.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isInTrigger){
            if(timer < 1.1f){
                timer += Time.deltaTime / moveTime;
            }
        }else{
            if(timer > -0.1f){
                timer -= Time.deltaTime / moveTime;
            }
        }
        foreach (ObjectsToLerp item in thingsToMove)
        {
            item.objectToMove.transform.position = Vector3.Lerp(item.startPos, item.endPos.position, timer);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            isInTrigger = true;
            player = other.transform;
            playerParent = player.parent;
            player.parent = thingsToMove[0].objectToMove.transform;
            
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            isInTrigger = false;
            player.parent = playerParent;
        }
        
    }
    [System.Serializable]
    public class ObjectsToLerp{
        [HideInInspector]
        public Vector3 startPos;
        public GameObject objectToMove;
        public Transform endPos;
        
    }
}
