using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DayNightCycle : MonoBehaviour {

    public float time;
    public TimeSpan currentTime;
    public Transform SunTransform;
    public Light Sun;
    public Text timetext;
    public int days;

    public float intensity;
    public Color fogday = Color.grey;
    public Color fognight = Color.black;

    public int speed;

    private void Update()
    {
        ChangeTime();
    }

    public void ChangeTime()
    {
       

        SunTransform.rotation = Quaternion.Euler(new Vector3((time - 21600) / 66500 * 360, 0, 0));
        if (time < 43200)
        {
            intensity = 1 - (43200 - time) / 43200;
        }
        else
        {
            intensity = 1 - ((43200 - time) / 43200 * -1);
        }
        RenderSettings.fogColor = Color.Lerp(fognight, fogday, intensity * intensity);

        Sun.intensity = intensity;
    }

}
