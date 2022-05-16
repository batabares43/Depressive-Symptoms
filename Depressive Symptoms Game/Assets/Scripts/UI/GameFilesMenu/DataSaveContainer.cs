using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataSaveContainer : MonoBehaviour
{
    public MetaData playerData;

    [SerializeField]private TMP_Text text;
    public void putData(MetaData p)
    {
        playerData = p;
        text.text = playerData.name;
    }

    public void loadData()
    {
        PathScript.Instance.FirstTime = false;
        PathScript.Instance.FinishedWeek = playerData.finishedWeek;
        PathScript.Instance.Id=playerData.id;
        PathScript.Instance.NamePlayer = playerData.name;
        PathScript.Instance.Location = playerData.location;
    }

}
