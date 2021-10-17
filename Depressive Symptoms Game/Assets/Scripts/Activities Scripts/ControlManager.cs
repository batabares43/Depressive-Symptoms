using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour, Subject
{
    private static ControlManager instance;
    private static List<Observer> activities;

    [Header("Variables areas de ajuste")]

    [SerializeField] private float hygiene;
    [SerializeField] private float environment;
    [SerializeField] private float jobPerformance;
    [SerializeField] private float academicPerformance;
    [SerializeField] private float sociability;
    [SerializeField] private float satiety;
    [SerializeField] private float rest;

    #region properties
    public float Hygiene { get => hygiene; set { hygiene = hygiene + value; notify(); } }
    public float Environment { get => environment; set { environment = environment + value; notify(); } }
    public float JobPerformance { get => jobPerformance; set { jobPerformance = jobPerformance + value; notify(); } }
    public float AcademicPerformance { get => academicPerformance; set { academicPerformance = academicPerformance + value; notify(); } }
    public float Sociability { get => sociability; set { sociability = sociability + value; notify(); } }
    public float Satiety { get => satiety; set { satiety = satiety + value; notify(); } }
    public float Rest { get => rest; set { rest = rest + value; notify(); } }


    public static ControlManager Instace { get => instance; }
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
        throw new System.NotImplementedException();
    }

    public void deSuscribe(Observer o)
    {
        throw new System.NotImplementedException();
    }
}
