using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntertainmentBar : MonoBehaviour, Observer
{
    private float maxCapacity = 24f;
    [SerializeField] private Slider bar;

    private void Start()
    {
        ControlManager.Instance.suscribe(this);
    }

    public void updateState()
    {
        float num = ControlManager.Instance.Entertainment;
        bar.value = num / maxCapacity;
    }
}
