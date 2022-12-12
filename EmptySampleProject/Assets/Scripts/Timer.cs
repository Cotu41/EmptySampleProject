using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// This timer component can be placed on any object. To use it, just get it with GetComponent and then subscribe anything you want to its OnTimerStart and OnTimerDone events, or use
/// the UnityEvents in the inspector.
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField]
    public float duration = 5f;

    [SerializeField]
    public UnityEvent OnStart, OnDone;

    public delegate void TimerEvent();
    public event TimerEvent OnTimerStart, OnTimerDone;

    float currentTime;
    bool running = false;

    /// <summary>
    /// Starts (or restarts) the timer
    /// </summary>
    public void StartTimer()
    {
        currentTime = duration;
        running = true;
        OnTimerStart?.Invoke();
        OnStart?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(running && currentTime > 0)
        {
            currentTime -= Time.deltaTime; // count down timer
        }

        if(running && currentTime <= 0)
        {
            running = false;
            OnTimerDone?.Invoke();
            OnDone?.Invoke();
        }
    }
}
