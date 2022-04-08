using UnityEngine;

namespace Relanima
{
    public class QuitGame : MonoBehaviour
    {
        public void ShutDownApplication()
        {
            Application.Quit();
            Debug.Log("Game shutting down...");
        }
    }
}
