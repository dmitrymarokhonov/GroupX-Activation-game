using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float time;
    public float fullDayLength;
    public float startTime;
    public bool timeRunning ;
    private float timeRate;
    private float timeSun;

    public Material morningSky;
    public Material daySky;
    public Material eveningSky;
    public Material nightSky;

    [Header("Sun")]
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;

    [Header("Other Lightning")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionsIntensityMultiplier;

    void Start()
    {
        startTime = 0.3f;
        timeRunning = false;
        timeRate = 1.0f / fullDayLength;
        time = startTime;
    }

    void Update()
    {
        if(timeRunning){
        time += timeRate * Time.deltaTime;
        }

        if(time <= 0.5f){
        RenderSettings.skybox.SetFloat("_Rotation", 360-time*360);
        }
        else if(time > 0.5f){
            RenderSettings.skybox.SetFloat("_Rotation", 360-(time-0.5f)*360);
        }

        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time*2);
        RenderSettings.reflectionIntensity
         = reflectionsIntensityMultiplier.Evaluate(time);

        if(time >= 1.0f){
            time = 0.0f;
        }

        if(time <= 0.5f){
            if(time <= 0.25f){
            sun.transform.eulerAngles = new Vector3(0+time*2*90, 90+time*2*180, 0.0f);
            }
            else if(time > 0.25f){
                sun.transform.eulerAngles = new Vector3(90-time*2*90, 90+time*2*180, 0.0f);
            }
        }

        if(time <= 0.5f){
        sun.intensity = sunIntensity.Evaluate(time*2);
        }
        else{
            sun.intensity = 0.0f;
        }

        sun.color = sunColor.Evaluate(time*2);

        if (time <= 0.17f){
            RenderSettings.skybox = morningSky;
        }
        else if(time <= 0.34f){
            RenderSettings.skybox = daySky;
        }
        else if (time <= 0.5f){
            RenderSettings.skybox = eveningSky;
        }
        else{
            RenderSettings.skybox = nightSky;
        }
    }
}
