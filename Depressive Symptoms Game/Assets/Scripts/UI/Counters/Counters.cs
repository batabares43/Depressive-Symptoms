using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counters : MonoBehaviour, Observer
{
    [SerializeField]private GameObject rotationPart;
    [SerializeField] private Text time;
    [SerializeField] private Text day;
    [SerializeField]private float angle=0.25f;
    [SerializeField] private int minute;


    private void Start()
    {
        TimeManager.Instance.suscribe(this);
    }
    public void updateState()
    {
        timeClock();
        
    }

    private void timeClock()
    {
        minute = TimeManager.Instance.LastMinuteChange;
        time.text = timeToString(TimeManager.Instance.Hour) + ":" + timeToString(TimeManager.Instance.Minute);
        day.text = "" + TimeManager.Instance.Day + "d";
        //rotationPart.transform.rotation = Quaternion.AngleAxis(angle * minute, new Vector3(0, 0, 1));
        rotationPart.transform.Rotate(new Vector3(0, 0,- angle * minute));
    }
    private string timeToString(int time)
    {
        string s = "";
        if (time < 10)
        {
            s = s + "0";
        }
        s = s + time;
        return s;
    }
    
}
