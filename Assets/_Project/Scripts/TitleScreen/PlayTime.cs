using System;
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
            if (parsedTime <= 5) return;
        
            _value = parsedTime - 5;
            UpdateTimeDisplay();
        }
        public void MoreTime()
        {
            _value = int.Parse(time.text) + 5;
            UpdateTimeDisplay();
        }

        private void UpdateTimeDisplay()
        {
            time.text = _value.ToString();
        }
    }
}
