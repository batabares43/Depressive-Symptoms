using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour, Subject
{
    private static RecordManager instance;
    private static List<Observer> activities = new List<Observer>();
    private List<Record> records = new List<Record>();
    private int combo = 0;
    private int lastCombo = 0;

    public int LastCombo {get => lastCombo;}

    public static RecordManager Instace { get => instance; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void addRecord(Record r)
    {
        if (records.Count > 0)
        {
            if (!records[records.Count - 1].nameActivity.Equals(r.nameActivity))
            {
                lastCombo = combo;
                combo = 0;
                notify();
            }
        }
        combo++;
        records.Add(r);
    }

    public void deSuscribe(Observer o)
    {
        activities.Remove(o);
    }

    public void notify()
    {
        foreach (Observer a in activities)
        {
            a.updateState();
        }
    }

    public void suscribe(Observer o)
    {
        activities.Add(o);
    }

}
