using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour, Subject
{
    private static TimeManager instance;
    private static List<Observer> activities;

    [Header("Variables de tiempo")]
    [SerializeField]private int day;
    [SerializeField]private int hour;
    [SerializeField]private int minute;

    

    #region properties
    public int Day { get => day;}
    public int Hour { get => hour;}
    public int Minute { get => minute;}

    public static TimeManager Instance { get => instance; }
    #endregion

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
    private void timeShift(int time)
    {
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
        notify();
    }
    

    public void notify()
    {
        foreach(Observer a in activities)
        {
            a.updateState();
        }
    }
    public void deSuscribe()
    {
        throw new System.NotImplementedException();
    }

    public void suscribe()
    {
        throw new System.NotImplementedException();
    }

    [ContextMenu("TestTime")]
    public void testTime()
    {
        int testMinutes = 10;
        timeShift(testMinutes);
    }
}
