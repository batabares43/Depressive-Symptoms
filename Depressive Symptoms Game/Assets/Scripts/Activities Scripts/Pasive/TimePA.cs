using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePA : MonoBehaviour, Observer
{
    [SerializeField] private Activity activityParams;
    [SerializeField]private int timeNext;


    private void Start()
    {
        TimeManager.Instance.suscribe(this);
        timeNext = activityParams.time;
    }

    public void updateState()
    {
        timeNext -= TimeManager.Instance.LastMinuteChange;
        while (timeNext <= 0){
            performActivity();
            timeNext += activityParams.time;
        }
    }

    private void performActivity()
    {
        Debug.Log(activityParams.name + gameObject.name);
        Record r = new Record(activityParams);
        VarManager.Instance.modificated(activityParams);
        ControlManager.Instance.modificated(activityParams);
        RecordManager.Instace.addRecord(r);
    }

    public void unSuscribe()
    {
        TimeManager.Instance.deSuscribe(this);
    }
    private void OnDestroy()
    {
        unSuscribe();
    }
}
