using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public Transform hoursTransform;
    public Transform munitesTrnaform;
    public Transform secondsTranform;
    public bool continuous;


    const float degreesPerHour   = 30f;
    const float degreesPerMinute = 6f;
    const float degreesPerSecond = 6f;


    void Awake()
    {
        Quaternion.Euler(-90f, 0f, 0f);
    }
    

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (continuous)
        {   
            UpdateContinuous();
        }
        else 
        {
            UpdateDiscrete();
        }
    }

    void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation  = Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
        munitesTrnaform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
        secondsTranform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
    }

    void UpdateDiscrete() 
    {
        DateTime time = DateTime.Now;
        hoursTransform.localRotation  = Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        munitesTrnaform.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
        secondsTranform.localRotation = Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
    }
}
