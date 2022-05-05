using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseButton : MonoBehaviour
{
    [SerializeField] private SpriteRenderer nose;

    public void changeNose(int i)
    {
        PlayerData.Instance.NoseIndex = i;
        chageSprites();
    }

    public void chageSprites()
    {

        nose.sprite = PlayerData.Instance.noses[PlayerData.Instance.NoseIndex];
    }

}
