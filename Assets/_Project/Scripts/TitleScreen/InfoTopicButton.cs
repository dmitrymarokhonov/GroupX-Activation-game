using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima.TitleScreen
{
    public class InfoTopicButton : MonoBehaviour
    {
        [SerializeField] private Color buttonActiveColor;
        [SerializeField] private Color buttonInactiveColor;
        
        [SerializeField] private List<Button> buttons;
        [SerializeField] private List<GameObject> panels;

        private int _currentActivePanel;
        private int _currentActiveButton;

        private void Start()
        {
            SetAllInactive();
            ActivateButton(0);
            ActivatePanel(0);
        }

        public void SetActive(int index)
        {
            if (index == _currentActiveButton) return;
            
            SetCurrentElementsInactive();
            ActivateButton(index);
            ActivatePanel(index);
        }

        private void ActivatePanel(int index)
        {
            _currentActivePanel = index;
            panels[index].SetActive(true);
        }

        private void ActivateButton(int index)
        {
            _currentActiveButton = index;
            buttons[index].GetComponent<Image>().color = buttonActiveColor;
            buttons[index].GetComponent<Shadow>().effectDistance = new Vector2(0, 0);
        }

        private void SetCurrentElementsInactive()
        {
            buttons[_currentActiveButton].GetComponent<Image>().color = buttonInactiveColor;
            buttons[_currentActiveButton].GetComponent<Shadow>().effectDistance = new Vector2(4, -4);
            panels[_currentActivePanel].SetActive(false);
        }

        private void SetAllInactive()
        {
            for (var i = 0; i < buttons.Count; i++)
            {
                var currentButton = buttons[i];
                currentButton.GetComponent<Image>().color = buttonInactiveColor;
                currentButton.GetComponent<Shadow>().effectDistance = new Vector2(4, -4);
                
                panels[i].SetActive(false);
            }
        }
    }
}
