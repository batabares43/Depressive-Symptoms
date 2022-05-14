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



    public static VarManager Instance { get => instance; }

    #endregion


    //variables que no pertenecen al sistema de medici�n
    private int energyIndex;
    private bool[] energyCategories = new bool[3];
    private float deadDesireTemp;
    private float sexualDesireTemp;
    private int riskIndex;
    private bool[] riskCategories = new bool[3];

    public void setVarManager(VarContainer v)
    {
        mood = v.mood;
        calories = v.calories;
        sleepHours = v.sleepHours;
        fitness = v.fitness;
        energy = v.energy;
        selfEfficacy = v.selfEfficacy;
        concentration = v.concentration;
        deadDesire = v.deadDesire;
        sexualDesire = v.sexualDesire;
        riskBehaviors = v.riskBehaviors;

        energyIndex = v.energyIndex;
        energyCategories = v.energyCategories;
        deadDesireTemp = v.deadDesireTemp;
        sexualDesireTemp = v.sexualDesireTemp;
        riskIndex = v.riskIndex;
        riskCategories = v.riskCategories;

    }
    public VarContainer GetVar()
    {
        VarContainer v = new VarContainer();
        v.mood = mood;
        v.calories = calories;
        v.sleepHours = sleepHours;
        v.fitness = fitness;
        v.energy = energy;
        v.selfEfficacy = selfEfficacy;
        v.concentration = concentration;
        v.deadDesire = deadDesire;
        v.sexualDesire = sexualDesire;
        v.riskBehaviors = riskBehaviors;

        v.energyIndex = energyIndex;
        v.energyCategories = energyCategories;
        v.deadDesireTemp = deadDesireTemp;
        v.sexualDesireTemp = sexualDesireTemp;
        v.riskIndex = riskIndex;
        v.riskCategories = riskCategories;
        return v;
    }
    public void modificated(Activity a)
    {
        mood += a.mood;
        calories += a.calories;
        sleepHours += a.sleepHours;
        fitness += a.fitness;
        energyIndex = (int)a.energy;
        selfEfficacy += a.selfEfficacy;
        concentration += a.concentration;
        deadDesireTemp = a.deadDesire;
        sexualDesireTemp = a.sexualDesire;
        riskIndex = (int)a.riskBehaviors;
        validateValues();
    }

    private void validateValues()
    {
        if (mood < -14)
        {
            mood = -14;
        }
        else if (mood > 14)
        {
            mood = 14;
        }
        if (fitness < 0)
        {
            fitness = 0;
        }
        else if (fitness > 30)
        {
            fitness = 30;
        }
        if (energyIndex > 0)
        {
            if (!energyCategories[energyIndex])
            {
                energy++;
            }
        }
        else if (energyIndex < 0)
        {
            if (energyCategories[energyIndex])
            {
                energy--;
            }
        }
        if (selfEfficacy < -10)
        {
            selfEfficacy = -10;
        }
        else if (selfEfficacy > 10)
        {
            selfEfficacy = 10;
        }
        if (concentration < -10)
        {
            concentration = -10;
        }
        else if (concentration > 10)
        {
            concentration = 10;
        }
        if (deadDesireTemp > deadDesire)
        {
            deadDesire = deadDesireTemp;
        }
        if (sexualDesireTemp > sexualDesire)
        {
            sexualDesire = sexualDesireTemp;
        }
        if (riskIndex > 0)
        {
            if (!riskCategories[energyIndex])
            {
                riskBehaviors++;
            }
        }
        else if (riskIndex < 0)
        {
            if (riskCategories[energyIndex])
            {
                riskBehaviors--;
            }
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
