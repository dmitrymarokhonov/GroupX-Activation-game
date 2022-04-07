using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainMenuController : MonoBehaviour{
    public GameObject Time;
    public Toggle toggle;
    public Toggle sound;
    public Text audioStatus;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        sound = GetComponent<Toggle>();
    }
    
    public void setTime()
    {
        if(toggle.isOn)
        {
            Time.SetActive(true);
        }
        else if (!toggle.isOn)
        {
            Time.SetActive(false);
        }
    }
    public void setAudio()
    {
        if (sound.isOn)
        {
            audioStatus.text = "Audio ON";
        }
        else
        {
            audioStatus.text = "Audio OFF";
        }
    }

    public void startGame()
    {
        //add first scene inside brackets
        //SceneManager.LoadScene()
    }
    public void loadGame()
    {
        //add needed functionalities to find loaded game, then call
        //startGame
    }



    public void exitYes()
    {
        Application.Quit();
        
        
    }

}
