using System;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima
{
    public class Timer : MonoBehaviour
    {
        public float timeRemainingSeconds;
        private bool _isRunning;

        public Text timerDisplay;
        
        private void Start()
        {
            _isRunning = true;
        }
        
        private void Update()
        {
            if (!_isRunning) return;

            if (timeRemainingSeconds > 0)
            {
                timeRemainingSeconds -= Time.deltaTime;
                DisplayTime(timeRemainingSeconds);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemainingSeconds = 0;
                _isRunning = false;
            }
        }

        private void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            var minutes = Math.Floor(timeToDisplay / 60);
            var seconds = Math.Floor(timeToDisplay % 60);
            timerDisplay.text = $"{minutes:00}:{seconds:00}";
        }
    }
}
