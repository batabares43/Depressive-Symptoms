using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatietyBar : MonoBehaviour, Observer
{
    private float maxCapacity = 8f;
    [SerializeField] private Slider bar;

    private void Start()
    {
        ControlManager.Instance.suscribe(this);
        updateState();
    }

    public void updateState()
    {
        float num = ControlManager.Instance.Satiety;
        bar.value = num / maxCapacity;
    }

    public void unSuscribe()
    {
        ControlManager.Instance.deSuscribe(this);
    }
}
