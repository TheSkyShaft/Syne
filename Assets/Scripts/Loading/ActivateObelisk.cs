using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ActivateObelisk : MonoBehaviour
{
    private bool canActivate, active;
    public Animator animator;
    public CinemachineVirtualCamera cam;
    private float timer;
    public int levelNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<FToInteract>().inside && !active){
            canActivate = true;
        }else{
            canActivate = false;
        }
        if(Input.GetKeyDown(KeyCode.F) && canActivate){
            animator.SetBool("ActivateObelisk", true);
            active = true;
            canActivate = false;
            cam.gameObject.SetActive(true);

            PlayerPrefs.SetInt("Level" + levelNumber.ToString() + "Complete", 1);
            PlayerPrefs.Save();
        }
        if(active){
            timer += Time.deltaTime;
            cam.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = timer; 
        }
    }
}
