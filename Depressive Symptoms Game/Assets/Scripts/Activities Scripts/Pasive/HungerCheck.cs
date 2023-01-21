using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerCheck : MonoBehaviour,Observer
{
    [SerializeField] private Activity hungry;
    [SerializeField] private Activity wellFed;
    private bool isHungry;

    public void unSuscribe()
    {
        ControlManager.Instance.deSuscribe(this);
    }

    public void updateState()
    {
        float saiety = ControlManager.Instance.Satiety;
        if (saiety <= 0 && !isHungry)
        {
            isHungry = true;
            performActivity(hungry);
        }else if (saiety > 4 && isHungry)
        {
            isHungry = false;
            performActivity(wellFed); 
        }
       
    }
    private void performActivity(Activity activityParams)
    {
        Record r = new Record(activityParams);
        VarManager.Instance.modificated(activityParams);
        ControlManager.Instance.modificated(activityParams);
        RecordManager.Instace.addRecord(r);
    }
    void Start()
    {
        ControlManager.Instance.suscribe(this);
    }

    private void OnDestroy()
    {
        unSuscribe();
    }
}
