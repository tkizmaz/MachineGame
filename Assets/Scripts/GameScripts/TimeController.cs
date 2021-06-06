using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;
    private float time = 0;

    private void Awake()
    {
        instance = this;
    }

    public int getTime()
    {
        return (int)time;
    }

    public void setTime(float time)
    {
        this.time += time;
    }

    public void BeginCountdown()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
    }
 
}
