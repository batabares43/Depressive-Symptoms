using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarManager : MonoBehaviour, Subject
{

    private static VarManager instance;
    private static List<Observer> activities;

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

    

    public static VarManager Instace { get => instance;}

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
