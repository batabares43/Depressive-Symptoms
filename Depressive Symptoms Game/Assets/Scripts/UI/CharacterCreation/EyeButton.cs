using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeButton : MonoBehaviour
{
    [SerializeField] private SpriteRenderer rEye;
    [SerializeField] private SpriteRenderer lEye;


    public void changeEye(int i)
    {
        PlayerData.Instance.EyeIndex = i;
        chageSprites();
    }

    public void changeEyeColor(int i)
    {
        PlayerData.Instance.EyeColor = i;
        chageSprites();
    }



    public void chageSprites()
    {
        
        rEye.sprite = PlayerData.Instance.eyes[PlayerData.Instance.EyeIndex];
        lEye.sprite = PlayerData.Instance.eyes[PlayerData.Instance.EyeIndex];
        rEye.color = PlayerData.Instance.eyesColors[PlayerData.Instance.EyeColor];
        lEye.color = PlayerData.Instance.eyesColors[PlayerData.Instance.EyeColor];



    }

}
