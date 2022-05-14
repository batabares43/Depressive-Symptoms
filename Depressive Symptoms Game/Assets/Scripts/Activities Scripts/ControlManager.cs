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

    // variables que no sos parte del sistema de medición
    private float useOfSPATemp;

    public void setControlManager(ControlContainer c) {
        hygiene= c.hygiene;
        environment = c.environment;
        jobPerformance = c.jobPerformance;
        academicPerformance = c.academicPerformance;
        sociability = c.sociability;
        satiety = c.satiety;
        rest = c.rest;
        bladder = c.bladder;
        entertainment = c.entertainment;
        useOfSPA = c.useOfSPA;

        useOfSPATemp = c.useOfSPATemp;
    }
    public ControlContainer GetControl()
    {
        ControlContainer c = new ControlContainer();
        c.hygiene = hygiene;
        c.environment = environment;
        c.jobPerformance = jobPerformance;
        c.academicPerformance = academicPerformance;
        c.sociability = sociability;
        c.satiety = satiety;
        c.rest = rest;
        c.bladder = bladder;
        c.entertainment = entertainment;
        c.useOfSPA = useOfSPA;

        c.useOfSPATemp = useOfSPATemp;
        return c;
    }
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
        useOfSPATemp = a.useOfSPA;
        validateValues();
        
    }

    private void validateValues() {
        if (hygiene < 0)
        {
            hygiene = 0;
        }
        else if (hygiene > 24)
        {
            hygiene = 24;
        }
        if (environment < 0)
        {
            environment = 0;
        }
        else if (environment > 12)
        {
            environment = 12;
        }
        if (academicPerformance < 0)
        {
            academicPerformance = 0;
        }
        else if (academicPerformance > 30)
        {
            academicPerformance = 30;
        }
        if (jobPerformance < 0)
        {
            jobPerformance = 0;
        }
        else if (jobPerformance > 40)
        {
            jobPerformance = 40;
        }
        if (sociability < 0)
        {
            sociability = 0;
        }
        else if (sociability > 20)
        {
            sociability = 20;
        }
        if (satiety < 0)
        {
            satiety = 0;
        }
        else if (satiety > 8)
        {
            satiety = 8;
        }
        if (rest < 0)
        {
            rest = 0;
        }
        else if (rest > 20)
        {
            rest = 20;
        }
        if (bladder < 0)
        {
            bladder = 0;
        }
        else if (bladder > 6)
        {
            bladder = 6;
        }
        if (entertainment < 0)
        {
            entertainment = 0;
        }
        else if (entertainment > 24)
        {
            entertainment = 24;
        }

        if (useOfSPATemp > useOfSPA)
        {
            useOfSPA = useOfSPATemp;
        }
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
