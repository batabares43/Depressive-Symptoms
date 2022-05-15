using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sadness : MonoBehaviour, Observer
{
    [SerializeField] private Activity activityParams;
    private bool isSad;

    private void Start()
    {
        VarManager.Instance.suscribe(this);
    }
    public void updateState()
    {
        if ((VarManager.Instance.DeadDesire ==0)&& (VarManager.Instance.Mood<=-10f)&& !isSad)
        {
            isSad = true;
            performActivity();
        }
    }
    private void performActivity()
    {
        Record r = new Record(activityParams);
        VarManager.Instance.modificated(activityParams);
        ControlManager.Instance.modificated(activityParams);
        RecordManager.Instace.addRecord(r);
    }
}
