using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairButton : MonoBehaviour
{
    [SerializeField] private SpriteRenderer fHair;
    [SerializeField] private SpriteRenderer bHair;

    public void changeHair(int i)
    {
        PlayerData.Instance.HairIndex = i;
        chageSprites();
    }

    public void changeHairColor(int i)
    {
        PlayerData.Instance.HairColor = i;
        chageSprites();
    }


    public void chageSprites()
    {
        
         fHair.sprite = PlayerData.Instance.fHairs[PlayerData.Instance.HairIndex];
         bHair.sprite = PlayerData.Instance.bHairs[PlayerData.Instance.HairIndex];
         fHair.color = PlayerData.Instance.hairColors[PlayerData.Instance.HairColor];
         bHair.color = PlayerData.Instance.hairColors[PlayerData.Instance.HairColor];
         
    }
}
