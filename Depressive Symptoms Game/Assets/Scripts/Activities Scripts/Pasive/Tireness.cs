using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tireness : MonoBehaviour,Observer
{
    [SerializeField]private Activity activityParams;
    private bool isTired;

    public void updateState()
    {
        float rest = ControlManager.Instance.Rest;
        if ( rest == 0 && !isTired){
            isTired = true;
            performActivity();
        }
        else
        {
            isTired = false;
        }
    }

    private void performActivity()
    {
        Record r = new Record(activityParams);
        VarManager.Instance.modificated(activityParams);
        ControlManager.Instance.modificated(activityParams);
        RecordManager.Instace.addRecord(r);
    }

    private void Start()
    {
        ControlManager.Instance.suscribe(this);
    }
}