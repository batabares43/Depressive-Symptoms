using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour
{
    [SerializeField] private GameObject view;
    public void instanceView()
    {
        Instantiate(view, GameObject.Find("Canvas").transform);
    }
}
