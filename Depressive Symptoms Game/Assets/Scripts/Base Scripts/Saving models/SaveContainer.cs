using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveContainer 
{
    public string id;
    public int location;
    public PlayerContainer player;
    public TimeContainer time;
    public VarContainer variables;
    public ControlContainer control;
    public RecordsContainer record;
}
