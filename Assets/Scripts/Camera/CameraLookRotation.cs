using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookRotation : MonoBehaviour
{
    public float xModifier = 5, yModifier = 5, minX = -40, maxX = 60, xFactor, xRota;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = -Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");

        
        
        x = x * xModifier * Time.fixedDeltaTime;
        y = y * yModifier * Time.fixedDeltaTime;
        Quaternion q = Quaternion.Euler(x + transform.eulerAngles.x, y + transform.eulerAngles.y, 0);
        x = Mathf.Lerp(transform.localRotation.x, x, Time.fixedDeltaTime);
        y = Mathf.Lerp(transform.localRotation.y, y, Time.fixedDeltaTime);
        float z = -Mathf.Lerp(transform.localRotation.z, 0, Time.fixedDeltaTime);
        transform.Rotate(x, y, z);
        
        //transform.rotation = q;
        // Euler angle quaternion does not like local rot quaternion, makes it spin :(
        //transform.rotation = Quaternion.Slerp(Quaternion.Euler(transform.localEulerAngles), q, Time.deltaTime);
        transform.rotation = ClampRotationAroundXAxis(transform.rotation);
    }
    Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

            angleX = Mathf.Clamp (angleX, minX, maxX);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }
}
