using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour,Observer
{
    [SerializeField] private Image panel;
    [SerializeField] private Color day;
    [SerializeField] private Color evening;
    [SerializeField] private Color night;

    public void updateState()
    {
        int hour = TimeManager.Instance.Hour;
        if ((hour >= 18 && hour<= 23) || (hour >= 0 && hour <= 6))
        {
            panel.color = night;
        }else if(hour>=16 && hour <= 17)
        {
            panel.color = evening;
        }
        else
        {
            panel.color = day;
        }

       


    }

   
    void Start()
    {
        panel = GameObject.Find("DayNight").GetComponent<Image>();
        TimeManager.Instance.suscribe(this);
        updateState();
    }

   
}
