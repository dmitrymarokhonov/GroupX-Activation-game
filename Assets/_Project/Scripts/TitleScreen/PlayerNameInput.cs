using Relanima.GameManager;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima.TitleScreen
{
    public class PlayerNameInput : MonoBehaviour
    {
        private InputField _inputField;
        
        private void Awake()
        {
            _inputField = GetComponent<InputField>();
            _inputField.onValueChanged.AddListener(UpdatePlayerName);
        }

        private void UpdatePlayerName(string plrName)
        {
            GameManagerElement.instance.SetPlayerName(plrName);
        }
    }
}