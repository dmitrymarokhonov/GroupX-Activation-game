using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Relanima.TitleScreen
{
    public class MainMenuController : MonoBehaviour
    {
        public GameObject Time;
        public Toggle toggle;
        public Toggle sound;
        public Text audioStatus;

        public void Start()
        {
            toggle = GetComponent<Toggle>();
            sound = GetComponent<Toggle>();
        }
    
        public void SetTime()
        {
            Time.SetActive(toggle.isOn);
        }
        public void SetAudio()
        {
            audioStatus.text = sound.isOn ? "Audio ON" : "Audio OFF";
        }

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
        public void LoadGame()
        {
            //add needed functionalities to find loaded game, then call
            //startGame
        }
    
        public void ExitYes()
        {
            Debug.Log("Quitting game...");
            Application.Quit();
        }

    }
}
