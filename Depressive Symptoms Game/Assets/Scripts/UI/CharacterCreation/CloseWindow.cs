using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    public void closeWindow()
    {
        foreach (GameObject p in panels)
        {
            p.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
