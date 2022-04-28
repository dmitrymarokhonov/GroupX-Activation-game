using UnityEngine;

namespace Relanima.GameManager
{
    public class GameManagerProxy : MonoBehaviour
    {
        public void StartGame()
        {
            GameManagerElement.instance.GoToGameField();
        }

        public void LogOut()
        {
            GameManagerElement.instance.LogOut();
        }
    }
}