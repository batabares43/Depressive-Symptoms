using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableActivity : ActivityBehavior
{
    [SerializeField] private ActivityManager target;
    [SerializeField] private int targetIndex;
    public override void activate()
    {
        target.activities[targetIndex].IsActive = false;
    }
}
