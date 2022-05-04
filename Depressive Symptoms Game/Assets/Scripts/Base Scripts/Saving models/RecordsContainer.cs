using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RecordsContainer{

    public List<RecordModel> records = new List<RecordModel>();
    //public List<RecordModel> Pasiverecords = new List<RecordModel>();
    public int combo;
    public int lastCombo;
}
