using UnityEngine;
using UnityEngine.UI;

namespace Relanima.TitleScreen
{
    public class InfoTopicButton : MonoBehaviour
    {
        public GameObject topicPanel;
        private Toggle _toggleButton;

        private void Start()
        {
            _toggleButton = GetComponent<Toggle>();
        }

        public void ShowPanel()
        {
            topicPanel.SetActive(_toggleButton.isOn);
        }
    }
}
