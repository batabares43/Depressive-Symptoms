using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelWindow : MonoBehaviour
{
    private Vector3 originalScale;
    [SerializeField] GameObject window;
    void Start()
    {
        originalScale = transform.localScale;
        
    }
    public void OnMouseOver()
    {
        if (!GameStateManager.Instance.InSelection)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStateManager.Instance.IsIdle = false;
                GameStateManager.Instance.InSelection = true;
                GameStateManager.Instance.AbleToMove = false;
                window.SetActive(true);
            }
        }
    }
    
    private void OnMouseEnter()
    {
        if (!GameStateManager.Instance.InSelection)
        {
            float hoverEffect = 1.01f;
            transform.localScale = new Vector3(transform.localScale.x * hoverEffect, transform.localScale.y * hoverEffect, transform.localScale.z);
        }
    }
    private void OnMouseExit()
    {
        transform.localScale = originalScale;
    }
}
