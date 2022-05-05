using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesoryButton : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Accesory;

    public void changeAccesory(int i) {
        PlayerData.Instance.AccesoryIndex = i;
        chageSprites();
    }

    public void chageSprites()
    {
        Accesory.sprite = PlayerData.Instance.Accesories[PlayerData.Instance.AccesoryIndex];
    }
}
