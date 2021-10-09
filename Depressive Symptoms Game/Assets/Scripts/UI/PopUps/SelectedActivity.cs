using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedActivity : MonoBehaviour
{
    [SerializeField] private ActivityFunctions activity;
    [SerializeField] private GameObject master;
    [SerializeField] private Text label;


    public void buildButton(ActivityFunctions activity, GameObject master)
    {
        this.master = master;
        this.activity = activity;
        label.text = this.activity.ActivityParams.nameActivity;
    }
    public void doActivity()
    {
        Destroy(master);
    }
}
