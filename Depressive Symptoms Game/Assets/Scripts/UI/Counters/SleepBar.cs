using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepBar : MonoBehaviour, Observer
{
    private float maxCapacity = 20f;
    [SerializeField] private Slider bar;

    private void Start()
    {
        ControlManager.Instance.suscribe(this);
        updateState();
    }

    public void updateState()
    {
        float num=ControlManager.Instance.Rest;
        bar.value = num / maxCapacity;
    }
}
