using UnityEngine;

namespace Relanima.GameManager
{
    public class GameManagerProxy : MonoBehaviour
    {
        public void StartGame()
        {
            GameManagerElement.instance.StartNewGame();
        }

        public void LoadGame()
        {
            GameManagerElement.instance.LoadGame();
        }

        public void LogOut()
        {
            GameManagerElement.instance.LogOut();
        }

        public void QuitFromTitleScreen()
        {
            Application.Quit();
        }

        public void SaveAndQuit()
        {
            GameManagerElement.instance.QuitGame();
        }

        public void ResetGameStatus()
        {
            GameManagerElement.instance.ResetGameStatus();
        }
        //
        // public void FilterLoadGameList()
        // {
        //     GameManagerElement.instance.FilterLoadGameList();
        // }
        
        public int RewardCount()
        {
            return GameManagerElement.instance.GetResources();
        }
    }
}