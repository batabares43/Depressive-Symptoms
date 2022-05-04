using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    private static PathScript instance;
    [SerializeField]private bool firstTime;
    [SerializeField]private string id;
    [SerializeField]private string namePlayer;

    #region properties
    public bool FirstTime { get=>firstTime; set=>firstTime=value; }
    public string Id { get=>id; set=>id=value; }
    public string NamePlayer { get=>namePlayer; set=>namePlayer=value; }

    #endregion
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
}
