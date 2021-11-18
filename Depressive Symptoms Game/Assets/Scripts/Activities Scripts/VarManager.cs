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
    public float Mood { get => mood; set { mood = mood + value; validateValues(); } }
    public float Calories { get => calories; set { calories = calories + value; validateValues(); } }
    public float SleepHours { get => sleepHours; set { sleepHours = sleepHours + value; validateValues(); } }
    public float Fitness { get => fitness; set { fitness = fitness + value; validateValues(); } }
    public float Energy { get => energy; set { energy = energy + value; validateValues(); } }
    public float SelfEfficacy { get => selfEfficacy; set { selfEfficacy = selfEfficacy + value; validateValues(); } }
    public float Concentration { get => concentration; set { concentration = concentration + value; validateValues(); } }
    public float DeadDesire { get => deadDesire; set { deadDesire = deadDesire + value; validateValues(); } }
    public float SexualDesire { get => sexualDesire; set { sexualDesire = sexualDesire + value; validateValues(); } }
    public float RiskBehaviors { get => riskBehaviors; set { riskBehaviors = riskBehaviors + value; validateValues(); } }



    public static VarManager Instance { get => instance;}

    #endregion


    public void modificated(Activity a)
    {
        mood += a.mood;
        calories += a.calories;
        sleepHours += a.sleepHours;
        fitness += a.fitness;
        energy += a.energy;
        selfEfficacy += a.selfEfficacy;
        concentration += a.concentration;
        deadDesire += a.deadDesire;
        sexualDesire += a.sexualDesire;
        riskBehaviors += a.riskBehaviors;
        validateValues();
    }

    private void validateValues()
    {
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
