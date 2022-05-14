using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour, Subject
{
    private static TimeManager instance;
    private static List<Observer> activities= new List<Observer>();

    [Header("Variables de tiempo")]
    [SerializeField] private int day;
    [SerializeField] private int hour;
    [SerializeField] private int minute;
    [SerializeField] private int lastMinuteChange;

    #region properties
    public int Day { get => day; }
    public int Hour { get => hour; }
    public int Minute { get => minute; }
    public int LastMinuteChange{get=>lastMinuteChange; }

    public static TimeManager Instance { get => instance; }
    #endregion

    public void setTimeManager(TimeContainer t)
    {
        day = t.day;
        hour = t.hour;
        minute = t.minute;
        lastMinuteChange = t.lastMinuteChange;
    }
    public TimeContainer GetTime()
    {
        TimeContainer t = new TimeContainer();
        t.day = day;
        t.hour = hour;
        t.minute = minute;
        t.lastMinuteChange = lastMinuteChange;
        return t;
    }
    private void Awake()
    {
        if (instance != null && instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void timeShift(Activity a)
    {
        int time = a.time;
        lastMinuteChange = time;
        minute += time;
        while (minute >= 60)
        {
            minute -= 60;
            hour++;
        }
        while (hour >= 24)
        {
            hour -= 24;
            day++;
        }
        Debug.Log("Time set");
        notify();
    }
    
    public void notify()
    {
        foreach(Observer a in activities)
        {
            a.updateState();
        }
    }
    public void deSuscribe(Observer o)
    {
        activities.Remove(o);
    }

    public void suscribe(Observer o)
    {
        activities.Add(o);
    }
}
