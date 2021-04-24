using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    
    
   
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
        if (Input.GetAxis("Horizontal")!=0)
        {
            Vector3 inputM = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            rb.MovePosition(transform.position + inputM * speed * Time.deltaTime);
        }
        
    }
    
 
}
