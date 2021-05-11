using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinButton : MonoBehaviour
{
    [SerializeField] public int bodyType;
    [SerializeField] public int skinIndex;

    [Header("Sprites pools")]
    [SerializeField] private Sprite[] heads;
    [SerializeField] private Sprite[] fBodies;
    [SerializeField] private Sprite[] mBodies;
    [SerializeField] private Sprite[] rArms;
    [SerializeField] private Sprite[] lArms;
    [SerializeField] private Sprite[] rhands;
    [SerializeField] private Sprite[] lhands;
    [SerializeField] private Sprite[] rfeet;
    [SerializeField] private Sprite[] lfeet;
    [SerializeField] private Sprite[] eyeLids;
    [SerializeField] private Sprite[] eyeLids2;
    [SerializeField] private Sprite[] eyeBags;


    [Header("Character parts")]
    [SerializeField] private SpriteRenderer head;
    [SerializeField] private SpriteRenderer body;
    [SerializeField] private SpriteRenderer rArm;
    [SerializeField] private SpriteRenderer lArm;
    [SerializeField] private SpriteRenderer rHand;
    [SerializeField] private SpriteRenderer lHand;
    [SerializeField] private SpriteRenderer rfoot;
    [SerializeField] private SpriteRenderer lfoot;
    [SerializeField] private SpriteRenderer rEyeLid;
    [SerializeField] private SpriteRenderer rEyeLid2;
    [SerializeField] private SpriteRenderer rEyeBag;
    [SerializeField] private SpriteRenderer lEyeLid;
    [SerializeField] private SpriteRenderer lEyeLid2;
    [SerializeField] private SpriteRenderer lEyeBag;


    public void sumBodyIndex()
    {
        bodyType++;
        if (bodyType > 1)
        {
            bodyType = 0;
        }
        chageSprites();
    }
    public void subBodyIndex()
    {
        bodyType--;
        if (bodyType < 0)
        {
            bodyType = 1;
        }
        chageSprites();
    }

    public void sumSkinIndex()
    {
        skinIndex++;
        if (skinIndex >= heads.Length)
        {
            skinIndex = 0;
        }
        chageSprites();
    }
    public void subSkinIndex()
    {
        skinIndex--;
        if (skinIndex < 0)
        {
            skinIndex = heads.Length-1;
        }
        chageSprites();
    }

    public void chageSprites()
    {
        if (bodyType == 0)
        {
            body.sprite = fBodies[skinIndex];
        }
        else
        {
            body.sprite = mBodies[skinIndex];
        }
        head.sprite = heads[skinIndex];
        rArm.sprite = rArms[skinIndex];
        lArm.sprite = lArms[skinIndex];
        rHand.sprite = rhands[skinIndex];
        lHand.sprite = lhands[skinIndex];
        rfoot.sprite = rfeet[skinIndex];
        lfoot.sprite = lfeet[skinIndex];
        rEyeLid.sprite = eyeLids[skinIndex];
        rEyeLid2.sprite = eyeLids2[skinIndex];
        rEyeBag.sprite = eyeBags[skinIndex];
        lEyeLid.sprite = eyeLids[skinIndex];
        lEyeLid2.sprite = eyeLids2[skinIndex];
        lEyeBag.sprite = eyeBags[skinIndex];

    }
}
