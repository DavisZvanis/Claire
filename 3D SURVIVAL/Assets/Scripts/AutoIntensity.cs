using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AutoIntensity : MonoBehaviour
{
    public Spawner spawner;
    public Item_Spawner itemSpawner;
    public Gradient nightDayColor;

    public float maxIntensity = 3f;
    public float minIntensity = 0f;
    public float minPoint = -0.2f;

    public float maxAmbient = 1f;
    public float minAmbient = 0f;
    public float minAmbientPoint = -0.2f;


    public Gradient nightDayFogColor;
    public AnimationCurve fogDensityCurve;
    public float fogScale = 1f;

    public float dayAtmosphereThickness = 0.4f;
    public float nightAtmosphereThickness = 0.87f;

    public Vector3 dayRotateSpeed;
    public Vector3 nightRotateSpeed;

    public float skySpeed = 1f;

    Light mainLight;
    Skybox sky;
    Material skyMat;

    public Transform center;

    //Time
    public float time;
    public TimeSpan currentTime;
    public Text timeText;
    public Text dayText;
    public int days;
    public int speed;

    void Start()
    {
       
        mainLight = GetComponent<Light>();
        skyMat = RenderSettings.skybox;
    }

    void Update()
    {
        time += Time.deltaTime * speed * skySpeed;
        if (time > 86400)
        {
            days += 1;
            dayText.text = "Day: " + days;
            time = 0;
            spawner.NewDay();
            itemSpawner.NewDayItems();
        }
        currentTime = TimeSpan.FromSeconds(time);
        string[] temtime = currentTime.ToString().Split(":"[0]);
        timeText.text = temtime[0] + ":" + temtime[1];

        float tRange = 1 - minPoint;
        float dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minPoint) / tRange);
        float i = ((maxIntensity - minIntensity) * dot) + minIntensity;

        mainLight.intensity = i;

        tRange = 1 - minAmbientPoint;
        dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minAmbientPoint) / tRange);
        i = ((maxAmbient - minAmbient) * dot) + minAmbient;
        RenderSettings.ambientIntensity = i;

        mainLight.color = nightDayColor.Evaluate(dot);
        RenderSettings.ambientLight = mainLight.color;

        RenderSettings.fogColor = nightDayFogColor.Evaluate(dot);
        RenderSettings.fogDensity = fogDensityCurve.Evaluate(dot) * fogScale;

        i = ((dayAtmosphereThickness - nightAtmosphereThickness) * dot) + nightAtmosphereThickness;
        skyMat.SetFloat("_AtmosphereThickness", i);

        if (dot > 0)
            transform.Rotate(dayRotateSpeed * Time.deltaTime * skySpeed);
        else
            transform.Rotate(nightRotateSpeed * Time.deltaTime * skySpeed);

       //if (Input.GetKeyDown(KeyCode.Q)) skySpeed *= 0.5f;
       //if (Input.GetKeyDown(KeyCode.E)) skySpeed *= 2f;


    }
}