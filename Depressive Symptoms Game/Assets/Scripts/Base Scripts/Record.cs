using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Record
{
    private string nameActivity;
    private bool isActive;
    private int day;
    private int hour;
    private int minute;
    private string folder;

    //private float mood;
    //private float calories;
    //private float sleepHours;
    //private float fitness;
    //private float energy;
    //private float selfEfficacy;
    //private float concentration;
    //private float deadDesire;
    //private float sexualDesire;
    //private float riskBehaviors;

    //private float hygiene;
    //private float environment;
    //private float jobPerformance;
    //private float academicPerformance;
    //private float sociability;
    //private float satiety;
    //private float rest;
    //private float bladder;
    //private float entertainment;
    //private float useOfSPA;

    #region properties

    public string NameActivity { get => nameActivity; }
    public bool IsActive { get => isActive; }

    public int Day { get => day; }
    public int Hour { get => hour; }
    public int Minute { get => minute; }

    public string Folder { get => folder; }

    //public float Mood { get => mood; }
    //public float Calories { get => calories; }
    //public float SleepHours { get => sleepHours; }
    //public float Fitness { get => fitness; }
    //public float Energy { get => energy; }
    //public float SelfEfficacy { get => selfEfficacy; }
    //public float Concentration { get => concentration; }
    //public float DeadDesire { get => deadDesire; }
    //public float SexualDesire { get => sexualDesire; }
    //public float RiskBehaviors { get => riskBehaviors; }

    //public float Hygiene { get => hygiene; }
    //public float Environment { get => environment; }
    //public float JobPerformance { get => jobPerformance; }
    //public float AcademicPerformance { get => academicPerformance; }
    //public float Sociability { get => sociability; }
    //public float Satiety { get => satiety; }
    //public float Rest { get => rest; }
    //public float Bladder { get => bladder; }
    //public float Entertainment { get => entertainment; }
    //public float UseOfSPA { get => useOfSPA; }

    #endregion
    public Record(Activity a)
    {
        nameActivity = a.nameActivity;
        isActive = a.active;
        day = TimeManager.Instance.Day;
        hour = TimeManager.Instance.Hour;
        minute = TimeManager.Instance.Minute;
        folder = a.folder + "/" + a.name;
        //mood = a.mood;
        //calories = a.calories;
        //sleepHours = a.sleepHours;
        //fitness = a.fitness;
        //energy = a.energy;
        //selfEfficacy = a.selfEfficacy;
        //concentration = a.concentration;
        //deadDesire = a.deadDesire;
        //sexualDesire = a.sexualDesire;
        //riskBehaviors = a.riskBehaviors;
        //hygiene = a.hygiene;
        //environment = a.environment;
        //jobPerformance = a.jobPerformance;
        //academicPerformance = a.academicPerformance;
        //sociability = a.sociability;
        //satiety = a.satiety;
        //rest = a.rest;
        //bladder = a.bladder;
        //entertainment = a.entertainment;
        //useOfSPA = a.useOfSPA;
    }
    public Record(RecordModel a)
    {
        nameActivity = a.nameActivity;
        isActive = a.isActive;
        day = a.day;
        hour = a.hour;
        minute = a.minute;
        folder = a.folder;
        //mood = a.mood;
        //calories = a.calories;
        //sleepHours = a.sleepHours;
        //fitness = a.fitness;
        //energy = a.energy;
        //selfEfficacy = a.selfEfficacy;
        //concentration = a.concentration;
        //deadDesire = a.deadDesire;
        //sexualDesire = a.sexualDesire;
        //riskBehaviors = a.riskBehaviors;
        //hygiene = a.hygiene;
        //environment = a.environment;
        //jobPerformance = a.jobPerformance;
        //academicPerformance = a.academicPerformance;
        //sociability = a.sociability;
        //satiety = a.satiety;
        //rest = a.rest;
        //bladder = a.bladder;
        //entertainment = a.entertainment;
        //useOfSPA = a.useOfSPA;
    }

    public RecordModel GetRecord()
    {
        RecordModel r = new RecordModel();
        r.nameActivity = nameActivity;
        r.isActive = isActive;
        r.day = day;
        r.hour = hour;
        r.minute = minute;
        r.folder = folder;
        //r.mood = mood;
        //r.calories = calories;
        //r.sleepHours = sleepHours;
        //r.fitness = fitness;
        //r.energy = energy;
        //r.selfEfficacy = selfEfficacy;
        //r.concentration = concentration;
        //r.deadDesire = deadDesire;
        //r.sexualDesire = sexualDesire;
        //r.riskBehaviors = riskBehaviors;
        //r.hygiene = hygiene;
        //r.environment = environment;
        //r.jobPerformance = jobPerformance;
        //r.academicPerformance = academicPerformance;
        //r.sociability = sociability;
        //r.satiety = satiety;
        //r.rest = rest;
        //r.bladder = bladder;
        //r.entertainment = entertainment;
        //r.useOfSPA = useOfSPA;
        return r;
    }
}
