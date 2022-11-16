using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [Header("Movement is abit weird due to platform scaling atm, math required")]
    private Vector3 pos1,pos2;
    [Header("Moves from current position to sphere collider 'Center'")]
    public float movementTime = 1;
    public float moveDistanceMultiplier = 1;
    private float timer = -1f;
    public bool autoActive = true;
    private void Start() {
        pos1 = transform.localPosition;
        pos2 = gameObject.GetComponent<SphereCollider>().center + pos1;
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }
    void Update()
    {
        if(autoActive){
            transform.localPosition = Vector3.Lerp(pos1 * moveDistanceMultiplier, pos2 * moveDistanceMultiplier, (Mathf.Sin(timer) + 1) / 2);
            timer += Time.deltaTime / movementTime;
        }else{
            autoActive = gameObject.GetComponent<DetectionNull>().enable;
        }
    }
}
