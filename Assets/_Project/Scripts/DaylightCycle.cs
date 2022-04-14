using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaylightCycle : MonoBehaviour
{
    [Header("Time settings")]
    [Range(0.0f, 1.0f)] public float time;
    private float timeMoon;
    private float timeRate;
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

    private void Start()
    {
        timeRate = 1.0f / fullDayLength;
        time = startTime;
    }

    private void Update()
    {
        if (!timeRunning) return;
        time += timeRate * Time.deltaTime;

        SkyBoxRotationBasedOnTime(time);

        ShutdownReflectionOnNight(time);

        SetTimeBackToStart(time);

        SetSunBasedOnTime(time);

        MoonIntensity(time);
        
        SetSkyBoxBasedOnTime(time);
    }

    private void SkyBoxRotationBasedOnTime(float time)
    {
        if (time <= 0.5f)
        {
            RenderSettings.skybox.SetFloat("_Rotation", 360-time*360);
        }
        else if (time > 0.5f)
        {
            RenderSettings.skybox.SetFloat("_Rotation", 360-(time-0.5f)*360);
        }
    }

    private void ShutdownReflectionOnNight(float time)
    {
        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity
         = reflectionsIntensityMultiplier.Evaluate(time);
    }
    private void SetTimeBackToStart(float time)
    {
        if (time >= 1.0f) 
            time = 0.0f;
    }

    private void SetSunBasedOnTime(float time)
    {
        SunRotation(time);
        SunIntensity(time);
        SunColor(time);
    }

    private void SunRotation(float time)
    {
        if (time <= 0.5f)
        {
            if (time <= 0.25f)
            {
                sun.transform.eulerAngles = new Vector3(20+time*2*50, 110+time*2*140, 0.0f);
            }
            else if (time > 0.25f)
            {
                sun.transform.eulerAngles = new Vector3(80-time*2*70, 100+time*2*160, 0.0f);
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

    private void SunIntensity(float time)
    {
        if (time <= 0.5f)
        {
            sun.intensity = sunIntensity.Evaluate(time*2);
        }
        else 
        {
            sun.intensity = 0.0f;
        }
    }

    private void SunColor(float time)
    {
        sun.color = sunColor.Evaluate(time*2);
    }

    private void MoonIntensity(float time)
    {
        if (time > 0.5f)
        {
            moon.intensity = moonIntensity.Evaluate(time*2);
        }
        else
        {
            moon.intensity = 0.0f;
        }
    }

    private void SetSkyBoxBasedOnTime(float time)
    {
        if (time <= 0.125f)
        {
            RenderSettings.skybox = earlyMorningSky;
        }
        else if (time <= 0.25f)
        {
            RenderSettings.skybox = morningSky;
        }
        else if (time <= 0.375f)
        {
            RenderSettings.skybox = daySky;
        }
        else if (time <= 0.5f)
        {
            RenderSettings.skybox = eveningSky;
        }
        else if (time <= 0.625)
        {
            RenderSettings.skybox = lateEveningSky;
        }
        else
        {
            RenderSettings.skybox = nightSky;
        }
    }
}
