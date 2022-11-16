using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextAnimator : MonoBehaviour
{
    private Text fToInteract;
    public float speedMultiplier = 1f;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        fToInteract = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(fToInteract.enabled){
            timer += Time.fixedDeltaTime * speedMultiplier;
            fToInteract.color = new Color(1, 1, 1, (Mathf.Sin(timer) + 1) / 2);    
        }else{
            timer = 0;
        }
    }
}
