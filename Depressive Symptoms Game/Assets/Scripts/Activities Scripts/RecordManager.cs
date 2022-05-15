using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour, Subject
{
    private static RecordManager instance;
    private static List<Observer> activities = new List<Observer>();
    private List<Record> records = new List<Record>();
    private List<Record> pasiverecords = new List<Record>();
    [SerializeField]private int combo = 0;
    [SerializeField] private int lastCombo = 0;
    [SerializeField] private string nameLast;


    public int LastCombo { get => lastCombo;}
    public string NameLast { get => nameLast;}

    public static RecordManager Instace { get => instance; }

    public void setRecordManager(RecordsContainer r)
    {
        foreach (RecordModel a in r.records)
        {
            records.Add(new Record(a));
        }
        foreach (RecordModel a in r.pasiverecords)
        {
            pasiverecords.Add(new Record(a));
        }
        combo = r.combo;
        lastCombo = r.lastCombo;
        nameLast = r.nameLast;

    }
    public RecordsContainer GetRecords()
    {
        RecordsContainer r = new RecordsContainer();
        foreach (Record a in records)
        {
            r.records.Add(a.GetRecord());
        }
        foreach (Record a in pasiverecords)
        {
            r.pasiverecords.Add(a.GetRecord());
        }
        r.combo = combo;
        r.lastCombo = lastCombo;
        r.nameLast = nameLast;
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
                    endRepetition(false);
                }
            }
            combo++;
            records.Add(r);
        }
        else
        {
            pasiverecords.Add(r);
        }

    }
    public void endRepetition(bool notificate)
    {
        lastCombo = combo;
        nameLast = records[records.Count - 1].NameActivity;
        combo = 0;
        if (notificate)
        {   
            notify();
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

