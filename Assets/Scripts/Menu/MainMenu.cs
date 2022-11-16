using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject creditsWindow;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt("Level" + i.ToString() + "Complete", 0);
            
        }

        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMenu(int level){
        SceneManager.LoadScene(level);
    }
    public void ExitMenu(){
        Application.Quit();
    }

    public void DisableCreditsWindow()
    {
        { 
            creditsWindow.SetActive(false);
        }
    }
    
    public void EnableCreditsWindow()
    {
        { 
            creditsWindow.SetActive(true);
        }
    }
    
}
