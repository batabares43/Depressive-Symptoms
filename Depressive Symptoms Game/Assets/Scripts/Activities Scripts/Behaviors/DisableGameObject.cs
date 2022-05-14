using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObject : ActivityBehavior
{
    [SerializeField] private GameObject target;
    public override void activate()
    {
        target.SetActive(false);
    }
}
