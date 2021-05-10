using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float axis;
    [SerializeField] public bool ableToMove =true; 
    
    
   
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        playerMovement();
    }
    private void playerMovement()
    {
        axis = Input.GetAxis("Horizontal");
        if (axis!=0 && ableToMove)
        {
            Vector2 inputM = new Vector2(axis, 0);
            Vector2 positionOffset = (Physics2D.gravity * rb.gravityScale) + inputM * speed;
            rb.MovePosition(rb.position + positionOffset * Time.deltaTime);
            
        }
       
        
    }
    
 
}
