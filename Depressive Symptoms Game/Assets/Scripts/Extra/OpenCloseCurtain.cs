using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseCurtain : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isOpen=true;
    private Animator anim;
    [SerializeField] private GameObject openedCurtain;
    [SerializeField] private GameObject closedCurtain;

    private void Start()
    {
        originalScale = gameObject.transform.localScale;
        anim = GetComponent<Animator>();
    }
    public void OnMouseOver()
    {
        if (!GameStateManager.Instance.InSelection)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isOpen)
                {
                    anim.Play("Close");
                }
                else
                {
                    anim.Play("Open");
                }
                isOpen = !isOpen;
                openedCurtain.SetActive(isOpen);
                closedCurtain.SetActive(!isOpen);
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
