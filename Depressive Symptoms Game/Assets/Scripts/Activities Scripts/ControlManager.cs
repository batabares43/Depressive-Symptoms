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

    public Record modificated(Record r,float hygiene, float environment, float jobPerformance, float academicPerformance, float sociability, float satiety, float rest, float bladder, float entertainment, float useOfSPA)
    {
        this.hygiene += hygiene;
        this.environment += environment;
        this.jobPerformance += jobPerformance;
        this.academicPerformance += academicPerformance;
        this.sociability += sociability;
        this.satiety += satiety;
        this.rest += rest;
        this.bladder += bladder;
        this.entertainment += entertainment;
        this.useOfSPA += useOfSPA;
        Debug.Log("Control set");
        notify();
        return r;
    }



    #region properties
    public float Hygiene { get => hygiene; set { hygiene = hygiene + value; notify(); } }
    public float Environment { get => environment; set { environment = environment + value; notify(); } }
    public float JobPerformance { get => jobPerformance; set { jobPerformance = jobPerformance + value; notify(); } }
    public float AcademicPerformance { get => academicPerformance; set { academicPerformance = academicPerformance + value; notify(); } }
    public float Sociability { get => sociability; set { sociability = sociability + value; notify(); } }
    public float Satiety { get => satiety; set { satiety = satiety + value; notify(); } }
    public float Rest { get => rest; set { rest = rest + value; notify(); } }
    public float Bladder { get => bladder; set { bladder = bladder + value; notify(); } }
    public float Entertainment { get => entertainment; set { entertainment = entertainment + value; notify(); } }
    public float UseOfSPA { get => useOfSPA; set { useOfSPA = useOfSPA + value; notify(); } }


    public static ControlManager Instance { get => instance; }
    #endregion

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
