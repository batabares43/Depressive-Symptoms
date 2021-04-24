using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationController : MonoBehaviour
{
    [SerializeField] public ActivityController activity;
    [SerializeField] private bool isInRange=false;
    [SerializeField] private bool inActivity = false;
    void Start()
    {
       
    }
    private void FixedUpdate()
    {
        if (isInRange)
        {
            if(Input.GetKey("e") && !inActivity)
            {
                inActivity = true;
                activity.activate();
            }
        }
        if(inActivity && activity.ended)
        {
            inActivity = false;
            activity.ended = false;
        }
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
