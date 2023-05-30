using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    private static PathScript instance;
    

    [SerializeField]private bool firstTime;
    [SerializeField]private string id;
    [SerializeField] private string namePlayer;
    [SerializeField] private int location;
    [SerializeField] private bool finishedWeek;
    [SerializeField] private bool cat = false;
    [SerializeField] private bool dog = false;
    [SerializeField] private bool work = false;
    [SerializeField] private bool study = false;

    #region properties
    public bool FirstTime { get=>firstTime; set=>firstTime=value; }
    public string Id { get=>id; set=>id=value; }
    public string NamePlayer { get=>namePlayer; set=>namePlayer=value; }
    public int Location { get => location; set => location = value; }
    public bool FinishedWeek { get => finishedWeek; set => finishedWeek = value; }
    public bool Cat { get => cat; set => cat = value; }
    public bool Dog { get => dog; set => dog = value; }
    public bool Work { get => work; set => work = value; }
    public bool Study { get => study; set => study = value; }
    public static PathScript Instance { get => instance; }

    #endregion
    private void Awake()
    {
        if (instance != this && instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            
        }
        
    }
}
