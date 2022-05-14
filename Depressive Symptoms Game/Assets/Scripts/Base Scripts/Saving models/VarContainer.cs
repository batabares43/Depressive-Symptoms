using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VarContainer
{
    public float mood;
    public float calories;
    public float sleepHours;
    public float fitness;
    public float energy;
    public float selfEfficacy;
    public float concentration;
    public float deadDesire;
    public float sexualDesire;
    public float riskBehaviors;

    public int energyIndex;
    public bool[] energyCategories = new bool[3];
    public float deadDesireTemp;
    public float sexualDesireTemp;
    public int riskIndex;
    public bool[] riskCategories = new bool[3];
}
