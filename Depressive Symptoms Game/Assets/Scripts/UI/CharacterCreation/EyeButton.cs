using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeButton : MonoBehaviour
{

    [SerializeField] public int eyeIndex;

    [Header("Sprites pools")]
    [SerializeField] private Sprite[] eyes;
    


    [Header("Character parts")]
    [SerializeField] private SpriteRenderer rEye;
    [SerializeField] private SpriteRenderer lEye;


    public void sumEyeIndex()
    {
        eyeIndex++;
        if (eyeIndex >= eyes.Length)
        {
            eyeIndex = 0;
        }
        chageSprites();
    }
    public void subEyeIndex()
    {
        eyeIndex--;
        if (eyeIndex < 0)
        {
            eyeIndex = eyes.Length - 1;
        }
        chageSprites();
    }
    public void chageSprites()
    {
        rEye.sprite = eyes[eyeIndex];
        lEye.sprite = eyes[eyeIndex];

    }

}
