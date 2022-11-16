using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCameraLook : MonoBehaviour
{
    public float rotateMultiplier = 90;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Horizontal");

        transform.Rotate(0,y * Time.deltaTime * rotateMultiplier, 0);
    }
}
