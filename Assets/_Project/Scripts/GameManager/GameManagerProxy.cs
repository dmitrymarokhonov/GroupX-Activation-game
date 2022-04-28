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
    }
}