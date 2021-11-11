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
        Record r = new Record();
        r = VarManager.Instance.modificated(r, activityParams.mood, 0, activityParams.sleepHours, 0, activityParams.energy, 0, 0, 0, 0, 0);
        r = ControlManager.Instance.modificated(r, activityParams.hygiene, 0, 0, 0, 0, activityParams.satiety, activityParams.rest, activityParams.bladder, activityParams.entertainment, 0);
    }
}
