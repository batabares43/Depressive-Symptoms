using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActivityOrder : ActivityBehavior
{
    [SerializeField] private ActivityManager target;
    [SerializeField] private int firstActivity;
    [SerializeField] private int targetActivity;
    public override void activate()
    {
        ActivityFunctions temp=target.activities[firstActivity];
        target.activities[firstActivity] = target.activities[targetActivity];
        target.activities[targetActivity] = temp;
    }

   
}
