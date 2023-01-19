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

    #region properties
    public bool FirstTime { get=>firstTime; set=>firstTime=value; }
    public string Id { get=>id; set=>id=value; }
    public string NamePlayer { get=>namePlayer; set=>namePlayer=value; }
    public int Location { get => location; set => location = value; }
    public bool FinishedWeek { get => finishedWeek; set => finishedWeek = value; }

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
