using System;
using TMPro;
using UnityEngine;

namespace Relanima
{
    public class Timer : MonoBehaviour
    {
        private float _timeRemainingSeconds;
        private bool _isRunning;

        public TMP_Text timerDisplay;
        public GameObject timerPanel;
        public GameObject dimmer;
        public GameObject dayNightCycle;
        private DaylightCycle _daylightCycle;
        
        private void Awake()
        {
            _daylightCycle = dayNightCycle.GetComponent<DaylightCycle>();
        }

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
                _isRunning = false;
                _timeRemainingSeconds = 0;
                dimmer.SetActive(true);
                timerPanel.SetActive(true);
                StopDaylightCycle();
            }
        }

        private void StopDaylightCycle()
        {
            _daylightCycle.StopCycle();
            _daylightCycle.SetSkyBoxBasedOnTime(0.27f);
            _daylightCycle.SetSunBasedOnTime(0.27f);
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

        public void DisableTimer()
        {
            _timeRemainingSeconds = 0;
            _isRunning = false;
            gameObject.SetActive(false);
        }
    }
}