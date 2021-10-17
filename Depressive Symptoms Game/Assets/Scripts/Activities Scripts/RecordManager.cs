using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour,Subject
{
    private static RecordManager instance;
    private static List<Observer> activities;
    private List<Record> records;
    private int combo=0;
    private int lastCombo=0;

    public static RecordManager Instace { get => instance; }
    public void addRecord(Record r)
    {
        if (records.Count > 0)
        {
            if (records[records.Count - 1].nameActivity.Equals(r.nameActivity))
            {
                combo++;
            }
            else
            {
                lastCombo = combo;
                combo = 1;
                notify();
            }
        }
        records.Add(r);
    }

    public void deSuscribe(Observer o)
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
    }

}
