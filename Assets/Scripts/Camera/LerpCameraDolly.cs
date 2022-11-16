using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCameraDolly : MonoBehaviour
{
    public float lerpFrom = 2,lerpTo = 0, lerpTime = 5f;
    private float lerpTimer;
    public bool enable;
    public Cinemachine.CinemachineVirtualCamera dollyCart;
    // Start is called before the first frame update
    void Start()
    {
        dollyCart = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enable){
            lerpTimer += Time.deltaTime / lerpTime;

            //dollyCart.GetCinemachineComponent<tracked = Mathf.Lerp(lerpFrom, lerpTo, lerpTimer);
        }
    }
}
