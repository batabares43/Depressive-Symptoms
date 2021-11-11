using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Actividad")]
public class Activity : ScriptableObject
{
    [Header("Parametros básicos")]
    
    [SerializeField] public string nameActivity;
    [SerializeField] public int time;
    [SerializeField] public bool active;

    [Header("Variables de sintomas")]

    [SerializeField] public float mood;
    [SerializeField] public float calories;
    [SerializeField] public float sleepHours;
    [SerializeField] public float fitness;
    [SerializeField] public float energy;
    [SerializeField] public float selfEfficacy;
    [SerializeField] public float concentration;
    [SerializeField] public float deadDesire;
    [SerializeField] public float sexualDesire;
    [SerializeField] public float riskBehaviors;

    [Header("Variables areas de ajuste")]

    [SerializeField] public float hygiene;
    [SerializeField] public float environment;
    [SerializeField] public float jobPerformance;
    [SerializeField] public float academicPerformance;
    [SerializeField] public float sociability;
    [SerializeField] public float satiety;
    [SerializeField] public float rest;
    [SerializeField] public float bladder;
    [SerializeField] public float entertainment;
    [SerializeField] public float useOfSPA;

}
