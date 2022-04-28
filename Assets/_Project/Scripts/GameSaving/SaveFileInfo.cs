using UnityEngine;
using UnityEngine.UI;

namespace Relanima.GameSaving
{
    public class SaveFileInfo : MonoBehaviour
    {
        public GameObject gameStatus;
        private Button _button;
        private Image _deleteIcon;

        private void Start()
        {
            gameStatus = GameObject.Find("Game Status").gameObject;
            _button = GetComponentInChildren<Button>();
            var name = _button.GetComponentsInChildren<Text>()[0].text;
            _button.onClick.AddListener(() => gameStatus.GetComponent<GameStatus>().LoadGameStatusByName(name));
        }
    }
}