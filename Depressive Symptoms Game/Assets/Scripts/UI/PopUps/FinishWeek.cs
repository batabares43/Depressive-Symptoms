using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishWeek : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public GameObject Target { set=> target=value ; }
    public void Update()
    {
        if (GameStateManager.Instance.AbleToMove)
        {
            if (TimeManager.Instance.Day >= 8 && !GameStateManager.Instance.FinishedWeek)
            {
                GameStateManager.Instance.IsPaused = true;
                GameStateManager.Instance.InSelection = true;
                GameStateManager.Instance.AbleToMove = false;
                GameStateManager.Instance.IsIdle = false;
                GameStateManager.Instance.FinishedWeek = true;
                target.SetActive(true);
            }
        }
    }
}
