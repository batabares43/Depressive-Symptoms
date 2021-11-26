using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform player;
    public float xmin;
    public float xmax;
    public float y;
    

    private void Update()
    {
        followPlayer();
    }
    private void followPlayer(){
        if (player.position.x > xmin && player.position.x < xmax)
        {
            Vector3 newPosition = new Vector3(player.position.x, y, transform.position.z);
            transform.position = newPosition;
        }

        

    }
}
