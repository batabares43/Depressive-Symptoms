using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour, Subject
{
    private static ControlManager instance;
    private static List<Observer> activities = new List<Observer>();

    [Header("Variables areas de ajuste")]

    [SerializeField] private float hygiene;
    [SerializeField] private float environment;
    [SerializeField] private float jobPerformance;
    [SerializeField] private float academicPerformance;
    [SerializeField] private float sociability;
    [SerializeField] private float satiety;
    [SerializeField] private float rest;
    [SerializeField] private float bladder;
    [SerializeField] private float entertainment;
    [SerializeField] private float useOfSPA;


    #region properties
    public float Hygiene { get => hygiene; set { hygiene = hygiene + value; validateValues(); } }
    public float Environment { get => environment; set { environment = environment + value; validateValues(); } }
    public float JobPerformance { get => jobPerformance; set { jobPerformance = jobPerformance + value; validateValues(); } }
    public float AcademicPerformance { get => academicPerformance; set { academicPerformance = academicPerformance + value; validateValues(); } }
    public float Sociability { get => sociability; set { sociability = sociability + value; validateValues(); } }
    public float Satiety { get => satiety; set { satiety = satiety + value; validateValues(); } }
    public float Rest { get => rest; set { rest = rest + value; validateValues(); } }
    public float Bladder { get => bladder; set { bladder = bladder + value; validateValues(); } }
    public float Entertainment { get => entertainment; set { entertainment = entertainment + value; validateValues(); } }
    public float UseOfSPA { get => useOfSPA; set { useOfSPA = useOfSPA + value; validateValues(); } }


    public static ControlManager Instance { get => instance; }
    #endregion

    public void modificated(Activity a)
    {
        hygiene += a.hygiene;
        environment += a.environment;
        jobPerformance += a.jobPerformance;
        academicPerformance += a.academicPerformance;
        sociability += a.sociability;
        satiety += a.satiety;
        rest += a.rest;
        bladder += a.bladder;
        entertainment += a.entertainment;
        useOfSPA += a.useOfSPA;
        validateValues();
        
    }

    private void validateValues() {
        notify();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void notify()
    {
        foreach (Observer a in activities)
        {
            a.updateState();
        }
    }

    public void suscribe(Observer o)
    {
        activities.Add(o);
    }

    public void deSuscribe(Observer o)
    {
        activities.Remove(o);
    }
}
