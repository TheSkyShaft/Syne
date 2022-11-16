using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public bool loadLevel;
    [Header("Find level number in build settings")]
    public int levelNumber = 0;
    public float transitionTime = 1f, delay = 0;
    public Image fadeImage;
    private float loadTimer;
    public bool confirmTeleport;
    private bool activate;
    private Color startColor;
    public GameObject portalAnimation;
    private void Start() {
        
        startColor = fadeImage.color;
    }
    void Update(){
        if(loadLevel && (!confirmTeleport || Input.GetKeyDown(KeyCode.F))){
            if(portalAnimation != null){
                portalAnimation.SetActive(true);
                Invoke("Load", transitionTime + delay);
                activate = true;
            }else{
                Invoke("Load", transitionTime + delay);
                activate = true;
            }
        }
        if(activate){
            loadTimer += Time.deltaTime;
            fadeImage.color =  new Color(startColor.r, startColor.g, startColor.b, (loadTimer / transitionTime) - delay / transitionTime);
        }
    }
    void OnTriggerEnter(Collider other){
        loadLevel = true;
    }
    void Load(){
        SceneManager.LoadScene(levelNumber);
    }
}