using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator anim;
    [SerializeField] private Vector2 target;
    [SerializeField] private bool moving = false;
    
    
   
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        target = transform.position;
    }
    private void Update()
    {
            playerMovement();
    }
    
    public void playerMovement(Vector2 target)
    {
        if (GameStateManager.Instance.AbleToMove)
        {
            this.target = target;
            this.target.y = transform.position.y;
            moving = true;
            playerMove();
        }
        
    }

    private void playerMovement()
    {
        
        if (GameStateManager.Instance.AbleToMove)
        {
            if (Input.GetMouseButtonDown(1))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.y = transform.position.y;
                moving = true; 
            }
            playerMove();
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
    private void playerMove()
    {
        if(moving && transform.position.x != target.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position.x < target.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (transform.position.x > target.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            anim.SetBool("isWalking", true);
        }
        else
        {
            moving = false;
            anim.SetBool("isWalking", false);
        }
    }

    


}
