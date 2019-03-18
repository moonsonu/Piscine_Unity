﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    public float fadeSpeed = 2f;
    public float highIntensity = 2f;
    public float lowIntensity = 0.5f;
    public float changeMargin = 0.2f;
    public bool isAlarm = false;
    public Light light;

    private float targetIntensity;

    private void Awake()
    {
        light.intensity = 0f;
        targetIntensity = highIntensity;
    }

    private void Update()
    {
        if (isAlarm)
        {
            light.intensity = Mathf.Lerp(light.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
            CheckTargetIntensity();
        }
        else
            light.intensity = Mathf.Lerp(light.intensity, 0f, fadeSpeed * Time.deltaTime);
    }

    void CheckTargetIntensity()
    {
        if (Mathf.Abs(targetIntensity - light.intensity) < changeMargin)
        {
            if (targetIntensity == highIntensity)
                targetIntensity = lowIntensity;
            else
                targetIntensity = highIntensity;
        }
    }
}
