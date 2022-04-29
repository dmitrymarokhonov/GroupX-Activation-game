using Relanima.GameManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima.GameSaving
{
    public class LoadSavedGame : MonoBehaviour
    {
        public void LoadFile()
        {
            var textElements = GetComponentsInChildren<TMP_Text>();
            var playerName = textElements[0].text;
            GameManagerElement.instance.SetPlayerName(playerName);
            var loadGameInput = GameObject.Find("Load Game Input Username").GetComponent<InputField>();
            loadGameInput.text = playerName;
        }
    }
}