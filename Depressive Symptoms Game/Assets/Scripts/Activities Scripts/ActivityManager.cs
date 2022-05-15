using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : MonoBehaviour
{

    [SerializeField] public List<ActivityFunctions> activities;
    [SerializeField] private bool instant;
    public bool Instant { get=>instant; set=>instant=value; }
    [SerializeField] private bool diponible;

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
        activities = new List<ActivityFunctions>(GetComponents<ActivityFunctions>());

    }

    public void showActivities()
    {
        GameStateManager.Instance.AbleToMove = false;
        GameStateManager.Instance.showSelectionMenu(gameObject, activities);
    }

    


    public void drawPlayer()
    {
        GameStateManager.Instance.Player.GetComponent<PlayerMovementController>().playerMovement(transform.position);
    }
    
    public void OnMouseOver()
    {
        if (!GameStateManager.Instance.InSelection)
        {
            if (Input.GetMouseButtonDown(0))
            {
                comprovateDisponability(); 
                if (!instant && diponible)
                {
                    drawPlayer();
                    showActivities();
                    
                }
                else
                {
                    foreach(ActivityFunctions a in activities)
                    {
                        if (a.IsActive)
                        {
                            a.activateActivity();
                        }
                    }
                }
                diponible = false;
            }
        }    
    }

    private void comprovateDisponability()
    {
        foreach(ActivityFunctions a in activities)
        {
            if (a.IsActive)
            {
                diponible = true;
            }
        }
    }

    private void OnMouseEnter()
    {
        comprovateDisponability();
        if (!GameStateManager.Instance.InSelection && diponible)
        {
            float hoverEffect = 1.01f;
            transform.localScale = new Vector3(transform.localScale.x * hoverEffect, transform.localScale.y * hoverEffect, transform.localScale.z);
        }
        diponible = false;
    }
    private void OnMouseExit()
    {
        transform.localScale = originalScale;
        
    }






}
