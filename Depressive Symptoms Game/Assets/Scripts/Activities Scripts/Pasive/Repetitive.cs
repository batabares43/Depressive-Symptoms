using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repetitive : MonoBehaviour,Observer
{
    [SerializeField] private Activity activityParams;
    [SerializeField] private string nameActivity;
    [SerializeField] private int limit;
    private bool isEnough;


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
        Debug.Log(RecordManager.Instace.NameLast +"||"+ RecordManager.Instace.LastCombo);
        if (RecordManager.Instace.NameLast.Equals(nameActivity)&& RecordManager.Instace.LastCombo>=limit &&!isEnough)
        {
            Debug.Log("pasive is performed");
            isEnough = true;
            activityParams.selfEfficacy = -RecordManager.Instace.LastCombo;
            performActivity();
        }else
        {
            Debug.Log("pasive is performed is not performed");
            isEnough = false;
        }
    }

    public void unSuscribe()
    {
        RecordManager.Instace.deSuscribe(this);
    }
    private void OnDestroy()
    {
        unSuscribe();
    }
}
