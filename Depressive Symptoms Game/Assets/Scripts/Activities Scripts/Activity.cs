using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Actividad")]
public class Activity : ScriptableObject
{
    [Header("Parametros básicos")]
    
    [SerializeField] public string nameActivity;
    [SerializeField] public float hours;
    [SerializeField] public bool active;

    [Header("Variables de sintomas")]

    [SerializeField] public float mood;
    [SerializeField] public float motivation;
    [SerializeField] public float calories;
    [SerializeField] public float sleepHours;
    [SerializeField] public float fitness;
    [SerializeField] public float energy;
    [SerializeField] public float selfEsteem;
    [SerializeField] public float concentration;
    [SerializeField] public float Will;

    [Header("Variables areas de ajuste")]

    [SerializeField] public float hygiene;
    [SerializeField] public float environment;
    [SerializeField] public float jobPerformance;
    [SerializeField] public float academicPerformance;
    [SerializeField] public float sociability;
    [SerializeField] public float satiety;
    [SerializeField] public float rest;

}
