using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CameraSensitivity : MonoBehaviour
{
    public GameObject xSlider, ySlider;
    public CinemachineFreeLook cam;

    public bool updateBaseCamRotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //xSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("ModifierCamX");
        //ySlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("ModifierCamY");

        //UpdateRotModifier();
        
    }

    // Update is called once per frame
    void Update()
    {
       if(updateBaseCamRotSpeed){
            updateBaseCamRotSpeed = false;
            UpdateRot();
        }
    }
    public void UpdateXSlider(){
        PlayerPrefs.SetFloat("ModifierCamX", xSlider.GetComponent<Slider>().value);
        PlayerPrefs.Save();
        UpdateRotModifier();
    }
    public void UpdateYSlider(){
        PlayerPrefs.SetFloat("ModifierCamY", ySlider.GetComponent<Slider>().value);
        PlayerPrefs.Save();
        UpdateRotModifier();
    }
    void UpdateRotModifier(){

        float x = PlayerPrefs.GetFloat("BaseCamY");
        float y = PlayerPrefs.GetFloat("BaseCamX");

        float xMod = PlayerPrefs.GetFloat("ModifierCamX");
        float yMod = PlayerPrefs.GetFloat("ModifierCamY");

        cam.m_XAxis.m_MaxSpeed = x * (xMod / 100);
        cam.m_YAxis.m_MaxSpeed = y * (yMod / 100);
    }
    void UpdateRot(){
        PlayerPrefs.SetFloat("BaseCamY", cam.m_YAxis.m_MaxSpeed);
        PlayerPrefs.SetFloat("BaseCamX", cam.m_XAxis.m_MaxSpeed);
        PlayerPrefs.Save();
    }
}
