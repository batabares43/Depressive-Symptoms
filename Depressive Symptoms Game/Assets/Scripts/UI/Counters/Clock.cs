using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour, Observer
{
    [SerializeField] private GameObject rotationPart;
    [SerializeField] private Text time;
    [SerializeField] private Text day;
    [SerializeField] private float angle = 0.25f;
    [SerializeField] private int minute;

    [SerializeField] private bool isMilitar=false;
    private bool isAfternoon;


    private void Start()
    {
        TimeManager.Instance.suscribe(this);
        updateState();
    }
    public void updateState()
    {
        timeClock();
    }

    private void timeClock()
    {
        minute = TimeManager.Instance.LastMinuteChange;
        time.text = timeToString(timePreference(TimeManager.Instance.Hour), true) + ":" + timeToString(TimeManager.Instance.Minute, false);
        day.text = "" + TimeManager.Instance.Day + "d";
        //rotationPart.transform.rotation = Quaternion.AngleAxis(angle * minute, new Vector3(0, 0, 1));
        rotationPart.transform.Rotate(new Vector3(0, 0, -angle * minute));
    }
    private string timeToString(int time, bool isHour)
    {
        string s = "";
        if (time < 10)
        {
            s = s + "0";
        }
        s = s + time;
        if(!isMilitar && !isHour && isAfternoon)
        {
            s = s + " PM";
        }else if (!isMilitar && !isHour)
        {
            s = s + " AM";
        }
        return s;
    }

    private int timePreference(int time)
    {
        if (!isMilitar)
        {
            int t;
            if(time >= 12)
            {
                t = time - 12;
                isAfternoon = true;
            }
            else
            {
                t = time;
                isAfternoon = false;
            }
            if(t == 0)
            {
                return 12;
            }
            return t;

        }
        return time;
    }

    private void OnDestroy()
    {
        unSuscribe();
    }

    public void unSuscribe()
    {
        TimeManager.Instance.deSuscribe(this);
    }

}
