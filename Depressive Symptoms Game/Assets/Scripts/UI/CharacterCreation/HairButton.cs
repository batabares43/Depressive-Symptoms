using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairButton : MonoBehaviour
{
    [SerializeField] public int hairIndex;

    [Header("Sprites pools")]
    [SerializeField] private Sprite[] fHairs;
    [SerializeField] private Sprite[] bHairs;



    [Header("Character parts")]
    [SerializeField] private SpriteRenderer fHair;
    [SerializeField] private SpriteRenderer bHair;

    public void sumHairIndex()
    {
        hairIndex++;
        if (hairIndex >= fHairs.Length)
        {
            hairIndex = 0;
        }
        chageSprites();
    }
    public void subHairIndex()
    {
        hairIndex--;
        if (hairIndex < 0)
        {
            hairIndex = fHairs.Length - 1;
        }
        chageSprites();
    }
    public void chageSprites()
    {
        fHair.sprite = fHairs[hairIndex];
        bHair.sprite = bHairs[hairIndex];

    }
}
