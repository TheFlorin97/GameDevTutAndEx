using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] Transform hoursPivot;
    [SerializeField] Transform minutesPivot;
    [SerializeField] Transform secondsPivote;

    const float hoursToDegrees = -30f, minutesToDegrees=-6f, secondsToDegrees=-6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    private void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        Debug.Log(DateTime.Now.Hour);
        hoursPivot.localRotation= Quaternion.Euler(0f, 0f,  hoursToDegrees* (float) time.TotalHours);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes);
        secondsPivote.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * (float)time.TotalSeconds);
    }
}
