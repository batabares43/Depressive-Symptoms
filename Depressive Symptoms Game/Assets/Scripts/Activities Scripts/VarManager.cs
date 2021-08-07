using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarManager : MonoBehaviour
{

    private static VarManager instace;

    [Header("Variables de sintomas")]

    [SerializeField] private float mood;
    [SerializeField] private float motivation;
    [SerializeField] private float calories;
    [SerializeField] private float sleepHours;
    [SerializeField] private float fitness;
    [SerializeField] private float energy;
    [SerializeField] private float selfEsteem;
    [SerializeField] private float concentration;
    [SerializeField] private float will;

    [Header("Variables areas de ajuste")]

    [SerializeField] private float hygiene;
    [SerializeField] private float environment;
    [SerializeField] private float jobPerformance;
    [SerializeField] private float academicPerformance;
    [SerializeField] private float sociability;
    [SerializeField] private float satiety;
    [SerializeField] private float rest;

    #region properties
    public float Mood { get => mood; set { mood = mood + value; notify(); } }
    public float Motivation { get => motivation; set { motivation = motivation + value; notify(); } }
    public float Calories { get => calories; set { calories = calories + value; notify(); } }
    public float SleepHours { get => sleepHours; set { sleepHours = sleepHours + value; notify(); } }
    public float Fitness { get => fitness; set { fitness = fitness + value; notify(); } }
    public float Energy { get => energy; set { energy = energy + value; notify(); } }
    public float SelfEsteem { get => selfEsteem; set { selfEsteem = selfEsteem + value; notify(); } }
    public float Concentration { get => concentration; set { concentration = concentration + value; notify(); } }
    public float Will { get => will; set { will = will + value; notify(); } }

    public float Hygiene { get => hygiene; set { hygiene = hygiene + value; notify(); } }
    public float Environment { get => environment; set { environment = environment + value; notify(); } }
    public float JobPerformance { get => jobPerformance; set { jobPerformance = jobPerformance + value; notify(); } }
    public float AcademicPerformance { get => academicPerformance; set { academicPerformance = academicPerformance + value; notify(); } }
    public float Sociability { get => sociability; set { sociability = sociability + value; notify(); } }
    public float Satiety { get => satiety; set { satiety = satiety + value; notify(); } }
    public float Rest { get => rest; set { rest = rest + value; notify(); } }

    public static VarManager Instace { get => instace;}

    #endregion

    private void Awake()
    {
        if (instace != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instace = this;
        }
    }
    private void notify()
    {
        Debug.Log("Notificando a observadores");
    }
}
