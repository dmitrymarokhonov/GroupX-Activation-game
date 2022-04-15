using System;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima
{
    public class SaveFileInfo : MonoBehaviour
    {
        public GameObject gameStatus;
        private Button button;
        private Image deleteIcon;

        private void Start()
        {
            gameStatus = GameObject.Find("Game Status").gameObject;
            button = GetComponentInChildren<Button>();
            var name = button.GetComponentsInChildren<Text>()[0].text;
            button.onClick.AddListener(() => gameStatus.GetComponent<GameStatus>().LoadGameStatusByName(name));
        }
    }
}
