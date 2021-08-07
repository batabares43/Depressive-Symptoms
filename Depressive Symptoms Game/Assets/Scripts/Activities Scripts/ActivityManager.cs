using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : MonoBehaviour
{

    [SerializeField] public Activity[] activities;
    [SerializeField] private bool isInRange=false;
    [SerializeField] private bool inActivity = false;

    [SerializeField] private Vector2 menuPosition;
    [SerializeField] private GameObject menuPrefab;
    [SerializeField] private GameObject menu;
    [SerializeField] private VarManager variables;

    private void Start()
    {
        variables = VarManager.Instace;
    }

    private void Update()
    {
        activation();
        
    }

    private void activation()
    {
        if (isInRange)
        {
            if (Input.GetKey("space") && !inActivity)
            {
                inActivity = true;
                //menu=Instantiate(menuPrefab, menuPosition, Quaternion.identity);
                menu.SetActive(true);
            }
        }
    }

    public void activitySelected()
    {
        menu.SetActive(false);
        //Destroy(menu);
        Debug.Log("Sleep");
        variables.SleepHours = activities[0].sleepHours;
        variables.Rest = activities[0].rest;
        inActivity = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInRange = false;
        }
    }

}
