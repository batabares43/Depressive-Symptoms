using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNPCs : MonoBehaviour
{
    [SerializeField] private int bodyType;
    [SerializeField] private int skinIndex;
    [SerializeField] private int eyeIndex;
    [SerializeField] private int eyeColor;
    [SerializeField] private int hairIndex;
    [SerializeField] private int hairColor;
    [SerializeField] private int mouthIndex;
    [SerializeField] private int noseIndex;
    [SerializeField] private int outfitIndex;
    [SerializeField] private int accesoryIndex;


    #region characterParts
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
    [SerializeField] private SpriteRenderer rEyeBag;
    [SerializeField] private SpriteRenderer lEyeLid;
    [SerializeField] private SpriteRenderer lEyeBag;
    [SerializeField] private SpriteRenderer rEye;
    [SerializeField] private SpriteRenderer lEye;
    [SerializeField] private SpriteRenderer fHair;
    [SerializeField] private SpriteRenderer bHair;
    [SerializeField] private SpriteRenderer mouth;
    [SerializeField] private SpriteRenderer nose;
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
    [SerializeField] private SpriteRenderer Accesory;
    #endregion

    void Start()
    {
        bodyType = Random.Range(0, 2);
        skinIndex = Random.Range(0, 4);
        eyeIndex = Random.Range(0, 3);
        eyeColor = Random.Range(0, 6);
        hairIndex = Random.Range(0, 8);
        hairColor = Random.Range(0, 6);
        noseIndex = Random.Range(0, 5);
        mouthIndex = Random.Range(0, 5);
        outfitIndex = Random.Range(0, 10);
        accesoryIndex = Random.Range(0, 3);
        changeSprites();
    }

    public void changeSprites()
    {

        if (PlayerData.Instance.BodyType == 0)
        {
            body.sprite = PlayerData.Instance.fBodies[skinIndex];
        }
        else
        {
            body.sprite = PlayerData.Instance.mBodies[skinIndex];
        }
        head.sprite = PlayerData.Instance.heads[skinIndex];
        rArm.sprite = PlayerData.Instance.rArms[skinIndex];
        lArm.sprite = PlayerData.Instance.lArms[skinIndex];
        rHand.sprite = PlayerData.Instance.rhands[skinIndex];
        lHand.sprite = PlayerData.Instance.lhands[skinIndex];
        rfoot.sprite = PlayerData.Instance.rfeet[skinIndex];
        lfoot.sprite = PlayerData.Instance.lfeet[skinIndex];
        rEyeLid.sprite = PlayerData.Instance.eyeLids[skinIndex];
        rEyeBag.sprite = PlayerData.Instance.eyeBags[skinIndex];
        lEyeLid.sprite = PlayerData.Instance.eyeLids[skinIndex];
        lEyeBag.sprite = PlayerData.Instance.eyeBags[skinIndex];
        fHair.sprite = PlayerData.Instance.fHairs[hairIndex];
        bHair.sprite = PlayerData.Instance.bHairs[hairIndex];
        fHair.color = PlayerData.Instance.hairColors[hairColor];
        bHair.color = PlayerData.Instance.hairColors[hairColor];
        rEye.sprite = PlayerData.Instance.eyes[eyeIndex];
        lEye.sprite = PlayerData.Instance.eyes[eyeIndex];
        rEye.color = PlayerData.Instance.eyesColors[eyeColor];
        lEye.color = PlayerData.Instance.eyesColors[eyeColor];
        nose.sprite = PlayerData.Instance.noses[noseIndex];
        mouth.sprite = PlayerData.Instance.mouths[mouthIndex];
        bodyO.sprite = PlayerData.Instance.tops[outfitIndex];
        rArmO.sprite = PlayerData.Instance.rArmsO[outfitIndex];
        lArmO.sprite = PlayerData.Instance.lArmsO[outfitIndex];
        rHandO.sprite = PlayerData.Instance.rhandsO[outfitIndex];
        lHandO.sprite = PlayerData.Instance.lhandsO[outfitIndex];
        rthighO.sprite = PlayerData.Instance.rthighsO[outfitIndex];
        lthighO.sprite = PlayerData.Instance.lthighsO[outfitIndex];
        rfootO.sprite = PlayerData.Instance.rfeetO[outfitIndex];
        lfootO.sprite = PlayerData.Instance.lfeetO[outfitIndex];
        skirt.sprite = PlayerData.Instance.skirts[outfitIndex];
        Accesory.sprite = PlayerData.Instance.Accesories[accesoryIndex];
        if (Random.Range(0, 2) == 1)
        {
            lEyeBag.gameObject.SetActive(true);
            rEyeBag.gameObject.SetActive(true);
        }

    }

}
