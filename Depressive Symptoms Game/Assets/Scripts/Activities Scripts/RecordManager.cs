using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour,Subject
{
    private static RecordManager instance;
    private static List<Observer> activities;
    private List<Record> records;

    public static RecordManager Instace { get => instance; }
    public void addRecord(Record r)
    {
        records.Add(r);
    }

    public void deSuscribe()
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

    public void suscribe()
    {
        throw new System.NotImplementedException();
    }

}
