using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : ActivityBehavior
{
    [SerializeField] private Vector3 newPosition;

    public override void activate()
    {
        GameStateManager.Instance.Player.transform.position = newPosition;
    }
}
