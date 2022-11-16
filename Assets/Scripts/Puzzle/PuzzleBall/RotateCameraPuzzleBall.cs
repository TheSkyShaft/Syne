using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraPuzzleBall : MonoBehaviour
{
    private Transform rotAround;
    // Start is called before the first frame update
    void Start()
    {
        rotAround = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        transform.RotateAround(rotAround.position, Vector3.up, x * 90 * Time.deltaTime);
    }
}
