using System;
using UnityEngine;

namespace Relanima
{
    public class DaylightCycle : MonoBehaviour
    {
        [Header("Time settings")]
        [Range(0.0f, 1.0f)] public float time;
        private float timeMoon;
        private float _timeRate;
        public float fullDayLength;
        public float startTime;
        public bool timeRunning;

        [Header("Skyboxes")]
        public Material earlyMorningSky;
        public Material morningSky;
        public Material daySky;
        public Material eveningSky;
        public Material lateEveningSky;
        public Material nightSky;

        [Header("Sun")]
        public Light sun;
        public Gradient sunColor;
        public AnimationCurve sunIntensity;

        [Header("Moon")]
        public Light moon;
        public AnimationCurve moonIntensity;

        [Header("Other Lightning")]
        public AnimationCurve lightingIntensityMultiplier;
        public AnimationCurve reflectionsIntensityMultiplier;
        private static readonly int Rotation = Shader.PropertyToID("_Rotation");

        private void Start()
        {
            // _timeRate = 1.0f / fullDayLength;
            time = startTime;
        }

        private void Update()
        {
            if (!timeRunning) return;
            time += _timeRate * Time.deltaTime;

            SkyBoxRotationBasedOnTime(time);

            ShutdownReflectionOnNight(time);

            SetTimeBackToStart(time);

            SetSunBasedOnTime(time);

            MoonIntensity(time);
        
            SetSkyBoxBasedOnTime(time);
        }

        private void SkyBoxRotationBasedOnTime(float currentTime)
        {
            if (currentTime <= 0.5f)
            {
                RenderSettings.skybox.SetFloat(Rotation, 360-currentTime*360);
            }
            else if (currentTime > 0.5f)
            {
                RenderSettings.skybox.SetFloat(Rotation, 360-(currentTime-0.5f)*360);
            }
        }

        private void ShutdownReflectionOnNight(float currentTime)
        {
            RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(currentTime);
            RenderSettings.reflectionIntensity
                = reflectionsIntensityMultiplier.Evaluate(currentTime);
        }
        private void SetTimeBackToStart(float currentTime)
        {
            if (currentTime >= 1.0f) 
                time = 0.0f;
        }

        public void SetSunBasedOnTime(float currentTime)
        {
            SunRotation(currentTime);
            SunIntensity(currentTime);
            SunColor(currentTime);
        }

        private void SunRotation(float currentTime)
        {
            if (currentTime <= 0.5f)
            {
                if (currentTime <= 0.25f)
                {
                    sun.transform.eulerAngles = new Vector3(20+currentTime*2*50, 110+currentTime*2*140, 0.0f);
                }
                else if (currentTime > 0.25f)
                {
                    sun.transform.eulerAngles = new Vector3(80-currentTime*2*70, 100+currentTime*2*160, 0.0f);
                }
                // Moon rotation is not implemented in this version.
                //} else if (time > 0.5f){
                //    if(time <= 0.75f){
                //    moon.transform.eulerAngles = new Vector3(0+timeMoon*2*90, 90+timeMoon*2*180, 0.0f);
                //    } else if(time > 0.75f){
                //        moon.transform.eulerAngles = new Vector3(90-timeMoon*2*90, 90+timeMoon*2*180, 0.0f);
                //    }
            }
        }

        private void SunIntensity(float currentTime)
        {
            sun.intensity = currentTime <= 0.5f ? sunIntensity.Evaluate(currentTime*2) : 0.0f;
        }

        private void SunColor(float currentTime)
        {
            sun.color = sunColor.Evaluate(currentTime*2);
        }

        private void MoonIntensity(float currentTime)
        {
            moon.intensity = currentTime > 0.5f ? moonIntensity.Evaluate(currentTime*2) : 0.0f;
        }

        public void SetSkyBoxBasedOnTime(float currentTime)
        {
            
            if (currentTime <= 0.125f)
            {
                RenderSettings.skybox = earlyMorningSky;
            }
            else if (currentTime <= 0.25f)
            {
                RenderSettings.skybox = morningSky;
            }
            else if (currentTime <= 0.375f)
            {
                RenderSettings.skybox = daySky;
            }
            else if (currentTime <= 0.5f)
            {
                RenderSettings.skybox = eveningSky;
            }
            else if (currentTime <= 0.625)
            {
                RenderSettings.skybox = lateEveningSky;
            }
            else
            {
                RenderSettings.skybox = nightSky;
            }
        }

        public void StartCycle()
        {
            if (fullDayLength == 0) return;
            timeRunning = true;
        }

        public void StopCycle()
        {
            timeRunning = false;
        }

        public void CalculateTimeRate(int timeInSeconds)
        {
            fullDayLength = timeInSeconds;
            _timeRate = 1.0f / fullDayLength;
        }
    }
}
