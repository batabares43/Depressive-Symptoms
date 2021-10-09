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
    public int Day { get => day; set { day = day + value; notify(); } }
    public int Hour { get => hour; set { hour = hour + value; notify(); } }
    public int Minute { get => minute; set { minute = minute + value; notify(); } }

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
}
