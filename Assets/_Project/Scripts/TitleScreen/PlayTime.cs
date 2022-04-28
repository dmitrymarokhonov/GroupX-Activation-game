using System;
using Relanima.GameManager;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima.TitleScreen
{
    public class PlayTime : MonoBehaviour
    {
        public Text time;
        private int _value;

        public void LessTime()
        {
            var parsedTime = int.Parse(time.text);
            if (parsedTime <= 0) return;
        
            _value = parsedTime - 5;
            UpdateGameManagerPlayTime();
            UpdateTimeDisplay();
        }

        private void UpdateGameManagerPlayTime()
        {
            GameManagerElement.instance.SetPlayTime(_value * 60);
        }

        public void MoreTime()
        {
            _value = int.Parse(time.text) + 5;
            UpdateGameManagerPlayTime();
            UpdateTimeDisplay();
        }

        private void UpdateTimeDisplay()
        {
            time.text = _value.ToString();
        }
    }
}
