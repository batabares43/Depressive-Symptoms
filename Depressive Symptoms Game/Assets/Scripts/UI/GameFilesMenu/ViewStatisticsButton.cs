using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewStatisticsButton : MonoBehaviour
{
    [SerializeField] private GameObject view;
    public void startView()
    {
        GameObject newView = Instantiate(view, GameObject.Find("Canvas").transform);
        newView.GetComponent<LoadCharacter>().startWindow(gameObject);
    }
}
