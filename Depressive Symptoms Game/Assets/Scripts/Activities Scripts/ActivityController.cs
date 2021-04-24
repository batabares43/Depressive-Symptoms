using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class ActivityController : MonoBehaviour
{
    [SerializeField] public bool ended=false;
    public abstract void activate();
    public abstract void endActivity();
}
