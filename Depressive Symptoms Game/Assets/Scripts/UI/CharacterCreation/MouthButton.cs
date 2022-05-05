using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthButton : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mouth;

    public void changeMouth(int i)
    {
        PlayerData.Instance.MouthIndex = i;
        chageSprites();
    }


    public void chageSprites()
    {

        mouth.sprite = PlayerData.Instance.mouths[PlayerData.Instance.MouthIndex];
    }
}
