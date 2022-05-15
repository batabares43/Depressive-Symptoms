using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : ActivityBehavior
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 newPosition;

    public override void activate()
    {
        target.transform.position = newPosition;
    }
}
