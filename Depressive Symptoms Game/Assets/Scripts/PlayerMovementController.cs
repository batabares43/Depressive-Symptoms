using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField] private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement2();
    }

    void playerMovement1()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        if (Input.GetKey("a"))
        {
            transform.position = new Vector2(x - speed * Time.deltaTime,y);
        }else if (Input.GetKey("d"))
        {
            transform.position = new Vector2(x + speed * Time.deltaTime, y);
        }
    }
    void playerMovement2()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        if (Input.GetKey("a"))
        {
            transform.position = new Vector2(x - speed * Time.deltaTime, y);
        }
        else if (Input.GetKey("d"))
        {
            transform.position = new Vector2(x + speed * Time.deltaTime, y);
        }else if (Input.GetKey("w"))
        {
            transform.position = new Vector2(x, y + speed * Time.deltaTime);
        }
        else if (Input.GetKey("s"))
        {
            transform.position = new Vector2(x, y - speed * Time.deltaTime);
        }
    }
}
