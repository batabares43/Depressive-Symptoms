using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladderBar : MonoBehaviour, Observer
{
    private float maxCapacity = 6f;
    [SerializeField] private Slider bar;

    private void Start()
    {
        ControlManager.Instance.suscribe(this);
    }

    public void updateState()
    {
        float num = ControlManager.Instance.Bladder;
        bar.value = num / maxCapacity;
    }
}
