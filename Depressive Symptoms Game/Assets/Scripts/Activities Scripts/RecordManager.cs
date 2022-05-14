using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour, Subject
{
    private static RecordManager instance;
    private static List<Observer> activities = new List<Observer>();
    private List<Record> records = new List<Record>();
    private List<Record> Pasiverecords = new List<Record>();
    private int combo = 0;
    private int lastCombo = 0;

    public int LastCombo {get => lastCombo;}

    public static RecordManager Instace { get => instance; }

    public void setRecordManager(RecordsContainer r) { }
    public RecordsContainer GetRecords()
    {
        RecordsContainer r = new RecordsContainer();
        return r;
    }
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
        if (r.IsActive)
        {
            if (records.Count > 0)
            {
                if (!records[records.Count - 1].NameActivity.Equals(r.NameActivity))
                {
                    lastCombo = combo;
                    combo = 0;
                    notify();
                }
            }
            combo++;
            records.Add(r);
        }
        else {
            Pasiverecords.Add(r);
        }
        
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
