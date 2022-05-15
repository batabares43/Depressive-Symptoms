using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInstant : ActivityBehavior
{
    [SerializeField] private ActivityManager target;
    public override void activate()
    {
        target.Instant = !target.Instant;
    }
}
