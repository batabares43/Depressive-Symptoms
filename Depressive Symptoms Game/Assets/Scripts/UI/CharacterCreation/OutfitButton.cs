using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitButton : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bodyO;
    [SerializeField] private SpriteRenderer rArmO;
    [SerializeField] private SpriteRenderer lArmO;
    [SerializeField] private SpriteRenderer rHandO;
    [SerializeField] private SpriteRenderer lHandO;
    [SerializeField] private SpriteRenderer rthighO;
    [SerializeField] private SpriteRenderer lthighO;
    [SerializeField] private SpriteRenderer rfootO;
    [SerializeField] private SpriteRenderer lfootO;
    [SerializeField] private SpriteRenderer skirt;

    public void changeOutfit(int i)
    {
        PlayerData.Instance.OutfitIndex = i;
        chageSprites();
    }

    public void chageSprites()
    {
        
        bodyO.sprite = PlayerData.Instance.tops[PlayerData.Instance.OutfitIndex];
        rArmO.sprite = PlayerData.Instance.rArmsO[PlayerData.Instance.OutfitIndex];
        lArmO.sprite = PlayerData.Instance.lArmsO[PlayerData.Instance.OutfitIndex];
        rHandO.sprite = PlayerData.Instance.rhandsO[PlayerData.Instance.OutfitIndex];
        lHandO.sprite = PlayerData.Instance.lhandsO[PlayerData.Instance.OutfitIndex];
        rthighO.sprite = PlayerData.Instance.rthighsO[PlayerData.Instance.OutfitIndex];
        lthighO.sprite = PlayerData.Instance.lthighsO[PlayerData.Instance.OutfitIndex];
        rfootO.sprite = PlayerData.Instance.rfeetO[PlayerData.Instance.OutfitIndex];
        lfootO.sprite = PlayerData.Instance.lfeetO[PlayerData.Instance.OutfitIndex];
        skirt.sprite = PlayerData.Instance.skirts[PlayerData.Instance.OutfitIndex];
    }
}
