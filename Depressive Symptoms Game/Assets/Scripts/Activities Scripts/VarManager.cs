using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarManager : MonoBehaviour, Subject
{

    private static VarManager instance;
    private static List<Observer> activities = new List<Observer>();

    [Header("Variables de sintomas")]

    [SerializeField] private float mood;
    [SerializeField] private float calories;
    [SerializeField] private float sleepHours;
    [SerializeField] private float fitness;
    [SerializeField] private float energy;
    [SerializeField] private float selfEfficacy;
    [SerializeField] private float concentration;
    [SerializeField] private float deadDesire;
    [SerializeField] private float sexualDesire;
    [SerializeField] private float riskBehaviors;


    #region properties
    public float Mood { get => mood; set { mood = mood + value; notify(); } }
    public float Calories { get => calories; set { calories = calories + value; notify(); } }
    public float SleepHours { get => sleepHours; set { sleepHours = sleepHours + value; notify(); } }
    public float Fitness { get => fitness; set { fitness = fitness + value; notify(); } }
    public float Energy { get => energy; set { energy = energy + value; notify(); } }
    public float SelfEfficacy { get => selfEfficacy; set { selfEfficacy = selfEfficacy + value; notify(); } }
    public float Concentration { get => concentration; set { concentration = concentration + value; notify(); } }
    public float DeadDesire { get => deadDesire; set { deadDesire = deadDesire + value; notify(); } }

    

    public static VarManager Instance { get => instance;}

    #endregion


    public Record modificated(Record r, float mood, float calories, float sleepHours, float fitness, float energy, float selfEfficacy, float concentration, float deadDesire, float sexualDesire, float riskBehaviors)
    {
        this.mood += mood;
        this.calories += calories;
        this.sleepHours += sleepHours;
        this.fitness += fitness;
        this.energy += energy;
        this.selfEfficacy += selfEfficacy;
        this.concentration += concentration;
        this.deadDesire += deadDesire;
        this.sexualDesire += sexualDesire;
        this.riskBehaviors += riskBehaviors;
        Debug.Log("Var set");
        notify();
        return r;
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
