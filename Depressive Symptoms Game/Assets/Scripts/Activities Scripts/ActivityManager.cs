using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : MonoBehaviour
{

    [SerializeField] public List<ActivityFunctions> activities;

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void showActivities()
    {
        GameStateManager.Instance.showSelectionMenu(gameObject, activities);
    }

    


    public void drawPlayer()
    {
        GameStateManager.Instance.Player.GetComponent<PlayerMovementController>().playerMovement(transform.position);
    }
    
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)){
            drawPlayer();
            showActivities();
        }
    }
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(transform.localScale.x * 1.1f, transform.localScale.y*1.1f ,transform.localScale.z);
    }
    private void OnMouseExit()
    {
        transform.localScale = originalScale;
    }






}
