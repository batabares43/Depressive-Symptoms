using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour,Observer
{
    [SerializeField] private Image panel;
    [SerializeField] private Color c;
    public void updateState()
    {
        panel = GameObject.Find("DayNight").GetComponent<Image>();
        float minutes = (TimeManager.Instance.Minute * 100) / 60;
        float temp = TimeManager.Instance.Hour;
        temp = temp + 12;
        temp = temp % 24;
        float hour = temp+minutes/100;

        float result = Mathf.Sin((hour*Mathf.PI)/24);
        temp = 100f / 255f;
        result = result*temp;      
        c.a = result;
        panel.color = c;

    }

   
    void Start()
    {
        TimeManager.Instance.suscribe(this);
        updateState();
    }

   
}
