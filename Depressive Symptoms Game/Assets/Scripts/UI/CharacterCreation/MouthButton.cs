using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthButton : MonoBehaviour
{
    [SerializeField] public int mouthIndex;

    [Header("Sprites pools")]
    [SerializeField] private Sprite[] mouths;



    [Header("Character parts")]
    [SerializeField] private SpriteRenderer mouth;
  


    public void sumMouthIndex()
    {
        mouthIndex++;
        if (mouthIndex >= mouths.Length)
        {
            mouthIndex = 0;
        }
        chageSprites();
    }
    public void subMouthIndex()
    {
        mouthIndex--;
        if (mouthIndex < 0)
        {
            mouthIndex = mouths.Length - 1;
        }
        chageSprites();
    }
    public void chageSprites()
    {
        mouth.sprite = mouths[mouthIndex];
    }
}
