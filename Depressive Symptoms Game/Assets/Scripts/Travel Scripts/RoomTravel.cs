using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTravel : MonoBehaviour
{
    private Vector3 originalScale;
    [SerializeField] private Transform player;
    [SerializeField] private Transform target;
    [SerializeField] private int targetIndex;
    [SerializeField] private float yOffset;
    [SerializeField] private CameraFollow cameraTarget;
    void Start()
    {
        originalScale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraTarget = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }
    public void OnMouseOver()
    {
        if (!GameStateManager.Instance.InSelection)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerTravel();
            }
        }
    }
    private void playerTravel()
    {
        Vector3 newPosition = new Vector3(target.position.x, yOffset, player.position.z);
        GameStateManager.Instance.Player.GetComponent<PlayerMovementController>().playerMovement(newPosition);
        player.position = newPosition;
        cameraTarget.IndexRoom = targetIndex;
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
