using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinButton : MonoBehaviour
{

    [SerializeField] private SpriteRenderer head;
    [SerializeField] private SpriteRenderer body;
    [SerializeField] private SpriteRenderer rArm;
    [SerializeField] private SpriteRenderer lArm;
    [SerializeField] private SpriteRenderer rHand;
    [SerializeField] private SpriteRenderer lHand;
    [SerializeField] private SpriteRenderer rfoot;
    [SerializeField] private SpriteRenderer lfoot;
    [SerializeField] private SpriteRenderer rEyeLid;
    [SerializeField] private SpriteRenderer rEyeBag;
    [SerializeField] private SpriteRenderer lEyeLid;
    [SerializeField] private SpriteRenderer lEyeBag;
    public void changeSex(int i)
    {
        PlayerData.Instance.BodyType = i;
        chageSprites();
    }
    public void changeSkin(int i)
    {
        PlayerData.Instance.SkinIndex = i;
        chageSprites();
    }

    public void chageSprites()
    {
        
        if (PlayerData.Instance.BodyType == 0)
        {
            body.sprite = PlayerData.Instance.fBodies[PlayerData.Instance.SkinIndex];
        }
        else
        {
            body.sprite = PlayerData.Instance.mBodies[PlayerData.Instance.SkinIndex];
        }
        head.sprite = PlayerData.Instance.heads[PlayerData.Instance.SkinIndex];
        rArm.sprite = PlayerData.Instance.rArms[PlayerData.Instance.SkinIndex];
        lArm.sprite = PlayerData.Instance.lArms[PlayerData.Instance.SkinIndex];
        rHand.sprite = PlayerData.Instance.rhands[PlayerData.Instance.SkinIndex];
        lHand.sprite = PlayerData.Instance.lhands[PlayerData.Instance.SkinIndex];
        rfoot.sprite = PlayerData.Instance.rfeet[PlayerData.Instance.SkinIndex];
        lfoot.sprite = PlayerData.Instance.lfeet[PlayerData.Instance.SkinIndex];
        rEyeLid.sprite = PlayerData.Instance.eyeLids[PlayerData.Instance.SkinIndex];
        rEyeBag.sprite = PlayerData.Instance.eyeBags[PlayerData.Instance.SkinIndex];
        lEyeLid.sprite = PlayerData.Instance.eyeLids[PlayerData.Instance.SkinIndex];
        lEyeBag.sprite = PlayerData.Instance.eyeBags[PlayerData.Instance.SkinIndex];


    }
}
