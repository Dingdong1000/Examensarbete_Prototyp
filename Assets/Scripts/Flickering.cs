using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(Light))]
public class Flickering : MonoBehaviour
{

    private Light lightToFlicker;
    [SerializeField, Range(0f, 3f)] private float minIntensity = 0.5f;
    [SerializeField, Range(0f, 3f)] private float maxIntensity = 1.2f;
    [SerializeField, Min(0f)] private float timeBetweenIntensity = 0.1f;

    private float currentTimer;

    private void Awake()
    {
        if (lightToFlicker == null)
        {
            lightToFlicker = GetComponent<Light>();
        }

        ValidateIntensityBounds();
    }

    private void ValidateIntensityBounds()
    {
        if (!(minIntensity > maxIntensity))
        {
            return;
        }
        Debug.Log("Min instenasfjaskdjnas");
        (minIntensity, maxIntensity) = (maxIntensity, minIntensity);
    }
}
