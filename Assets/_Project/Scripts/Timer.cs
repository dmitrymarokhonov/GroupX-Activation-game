using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima
{
    public class Timer : MonoBehaviour
    {
        private float _timeRemainingSeconds;
        private bool _isRunning;

        public TMP_Text timerDisplay;
 
        private void Update()
        {
            if (!_isRunning) return;

            if (_timeRemainingSeconds > 0)
            {
                _timeRemainingSeconds -= Time.deltaTime;
                DisplayTime(_timeRemainingSeconds);
            }
            else
            {
                Debug.Log("Time has run out!");
                _timeRemainingSeconds = 0;
                _isRunning = false;
            }
        }

        private void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            if (timeToDisplay >= 3600)
            {
                DisplayHoursMinutesSeconds(timeToDisplay);
            }
            else
            {
                DisplayMinutesSeconds(timeToDisplay);
            }
        }

        private void DisplayHoursMinutesSeconds(float timeToDisplay)
        {
            var hours = Math.Floor(timeToDisplay / 3600);
            var minutes = Math.Floor(timeToDisplay / 60 % 60);
            var seconds = Math.Floor(timeToDisplay % 60);
            timerDisplay.text = $"{hours:0}h {minutes:00}min {seconds:00}s";
        }

        private void DisplayMinutesSeconds(float timeToDisplay)
        {
            var minutes = Math.Floor(timeToDisplay / 60);
            var seconds = Math.Floor(timeToDisplay % 60);
            timerDisplay.text = $"{minutes:00}min {seconds:00}s";
        }

        public void SetTimeRemainingInSeconds(int seconds)
        {
            _timeRemainingSeconds = seconds;
        }
        
        public void StartTimer()
        {
            _isRunning = true;
        }

        public void StopTimer()
        {
            _isRunning = false;
        }
    }
}