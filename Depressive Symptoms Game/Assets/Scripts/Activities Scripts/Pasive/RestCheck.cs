using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCheck : MonoBehaviour,Observer
{
    [SerializeField] private Activity activityParams;
    [SerializeField] private string nameActivity;


    void Start()
    {
        RecordManager.Instace.suscribe(this);
    }
    private void performActivity()
    {
        Record r = new Record(activityParams);
        VarManager.Instance.modificated(activityParams);
        ControlManager.Instance.modificated(activityParams);
        RecordManager.Instace.addRecord(r);
    }

    public void updateState()
    {
        if (RecordManager.Instace.NameLast.Equals(nameActivity))
        {
            if(RecordManager.Instace.LastCombo<7 || RecordManager.Instace.LastCombo > 9)
            {
                Debug.Log("Wake up tired");
                activityParams.energy = -2;
                activityParams.concentration = 0;
                activityParams.rest = 0;
            }
            else
            {
                Debug.Log("Wake up restful");
                activityParams.energy = 2;
                activityParams.concentration = 1;
                activityParams.rest = RecordManager.Instace.LastCombo;
            }
            performActivity();
        }
    }
}
