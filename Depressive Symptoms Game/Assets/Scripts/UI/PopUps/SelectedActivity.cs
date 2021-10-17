using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedActivity : MonoBehaviour
{
    [SerializeField] private ActivityFunctions activity;
    [SerializeField] private GameObject master;
    [SerializeField] private TextMeshProUGUI label;


    public void buildButton(ActivityFunctions activity, GameObject master)
    {
        this.master = master;
        this.activity = activity;
        label.SetText(this.activity.ActivityParams.nameActivity);
    }
    public void doActivity()
    {
        activity.activateActivity();
        Destroy(master);
    }
}
