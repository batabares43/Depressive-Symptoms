using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLooks : MonoBehaviour
{
    private static PlayerLooks instance;
    public static PlayerLooks Instance { get => instance; }

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

    public void setPlayerLooks(PlayerContainer p)
    {
        bodyType = p.bodyType;
        skinIndex = p.skinIndex;
        eyeIndex = p.eyeIndex;
        eyeColor = p.eyeColor;
        hairIndex = p.hairIndex;
        hairColor = p.hairColor;
        noseIndex = p.noseIndex;
        mouthIndex = p.mouthIndex;
        outfitIndex = p.outfitIndex;
        accesoryIndex = p.accesoryIndex;
        changeSprites();

    }
    public PlayerContainer GetPlayer()
    {
        PlayerContainer p = new PlayerContainer();
        p.bodyType = bodyType;
        p.skinIndex = skinIndex;
        p.eyeIndex = eyeIndex;
        p.eyeColor = eyeColor;
        p.hairIndex = hairIndex;
        p.hairColor = hairColor;
        p.noseIndex = noseIndex;
        p.mouthIndex = mouthIndex;
        p.outfitIndex = outfitIndex;
        p.accesoryIndex = accesoryIndex;
        return p;
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


    }
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            if (instance != null && instance != this)
            {
                instance.gameObject.transform.position = gameObject.transform.position;
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                SceneManager.sceneLoaded += instance.OnSceneLoaded;
            }
        }
   
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "Main Menu")
        {

            try
            {
                SceneManager.sceneLoaded -= instance.OnSceneLoaded;
                Destroy(instance.gameObject);
                instance = null;

            }
            catch
            {
            }
        }
    }
    void OnDisable()
    {
        try
        {
            SceneManager.sceneLoaded -= instance.OnSceneLoaded;
        }
        catch
        {

        }
        
    }
}
