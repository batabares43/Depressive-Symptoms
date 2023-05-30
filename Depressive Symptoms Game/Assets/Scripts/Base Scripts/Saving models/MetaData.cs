using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MetaData
{
    //general data
    public string id;
    public string name;
    public bool finishedWeek;
    public int location;

    //Pets
    public bool dog;
    public bool cat;

    //Work and study
    public bool work;
    public bool study;
}
