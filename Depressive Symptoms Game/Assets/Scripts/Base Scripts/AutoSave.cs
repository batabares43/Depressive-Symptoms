using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour, Observer
{
    private int hoursPassed = 0;
    private int minutesPassed = 0;

    private void Start()
    {
        TimeManager.Instance.suscribe(this);
    }
    public void updateState() {
        minutesPassed += TimeManager.Instance.LastMinuteChange;
        while (minutesPassed >= 60)
        {
            minutesPassed -= 60;
            hoursPassed++;
        }
        if (hoursPassed >= 6)
        {
            hoursPassed -= 6;
            GameStateManager.Instance.Save();
            MetaSaveLoad.Instance.updateData(GameStateManager.Instance.getMetaData());
        }
       
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
