using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private List<float> xmin = new List<float>();
    [SerializeField]private List<float> xmax = new List<float>();
    [SerializeField]private List<float> y = new List<float>();
    [SerializeField] private List<Transform> targets = new List<Transform>();

    [SerializeField]private int indexRoom=0;

    public int IndexRoom { get=>indexRoom; set { indexRoom = value; changeCameraPosition(); } }
    private void Start()
    {
        player= PlayerLooks.Instance.gameObject.transform;
        changeCameraPosition();
    }
    private void Update()
    {
        followPlayer();
    }
    private void followPlayer(){
        float xPosition = player.position.x;
        if (player.position.x < xmin[indexRoom])
        {
            xPosition = xmin[indexRoom];
        }
        else if (player.position.x > xmax[indexRoom])
        {
            xPosition = xmax[indexRoom];
        }
        Vector3 newPosition = new Vector3(xPosition, y[indexRoom], transform.position.z);
        transform.position = newPosition;
    }
    private void changeCameraPosition()
    {
        Vector3 newPosition = new Vector3(targets[indexRoom].position.x, targets[indexRoom].position.y, transform.position.z);
        transform.position = newPosition;
    }
}
