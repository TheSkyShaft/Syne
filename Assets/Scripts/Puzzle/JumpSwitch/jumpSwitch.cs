using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpSwitch : MonoBehaviour
{
    public bool flip;
    private bool flipWay = true;
    private float flipTimer;
    public float flipTimeMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(flip){
            transform.localRotation = Quaternion.Lerp(Quaternion.Euler(0,0,0), Quaternion.Euler(-180,0,0), flipTimer);
            if(flipWay){
                if(flipTimer < 1){
                    flipTimer += Time.deltaTime * flipTimeMultiplier;
                }else{
                    flip = false;
                    flipWay = !flipWay;
                }
            }else{
                if(flipTimer > 0){
                    flipTimer -= Time.deltaTime * flipTimeMultiplier;
                }else{
                    flip = false;
                    flipWay = !flipWay;
                }
            }
        }
    }
}
