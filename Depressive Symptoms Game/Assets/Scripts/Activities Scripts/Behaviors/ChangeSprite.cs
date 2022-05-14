using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : ActivityBehavior
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private SpriteRenderer target;

    public override void activate()
    {
        target.sprite = sprite;
    }
}
