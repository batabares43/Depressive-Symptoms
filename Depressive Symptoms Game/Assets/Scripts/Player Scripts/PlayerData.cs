using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private static PlayerData instance;
    public static PlayerData Instance { get => instance; }

    

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

    #region sprite pools

    [Header("Sprites skin")]

    [SerializeField] public Sprite[] heads;
    [SerializeField] public Sprite[] fBodies;
    [SerializeField] public Sprite[] mBodies;
    [SerializeField] public Sprite[] rArms;
    [SerializeField] public Sprite[] lArms;
    [SerializeField] public Sprite[] rhands;
    [SerializeField] public Sprite[] lhands;
    [SerializeField] public Sprite[] rfeet;
    [SerializeField] public Sprite[] lfeet;
    [SerializeField] public Sprite[] eyeLids;
    [SerializeField] public Sprite[] eyeBags;
    

    [Header("Sprites face")]

    [SerializeField] public Sprite[] eyes;
    [SerializeField] public Sprite[] mouths;
    [SerializeField] public Sprite[] noses;
    [SerializeField] public Sprite[] fHairs;
    [SerializeField] public Sprite[] bHairs;

    [Header("Sprites outfit")]

    [SerializeField] public Sprite[] tops;
    [SerializeField] public Sprite[] rArmsO;
    [SerializeField] public Sprite[] lArmsO;
    [SerializeField] public Sprite[] rhandsO;
    [SerializeField] public Sprite[] lhandsO;
    [SerializeField] public Sprite[] rthighsO;
    [SerializeField] public Sprite[] lthighsO;
    [SerializeField] public Sprite[] rfeetO;
    [SerializeField] public Sprite[] lfeetO;
    [SerializeField] public Sprite[] skirts;
    [SerializeField] public Sprite[] Accesories;

    [Header("colors")]

    [SerializeField] public Color[] eyesColors;
    [SerializeField] public Color[] hairColors;

    #endregion

    #region properties
    public int BodyType { get=>bodyType; set=>bodyType=value; }
    public int SkinIndex { get => skinIndex; set => skinIndex = value; }
    public int EyeIndex { get => eyeIndex; set => eyeIndex = value; }
    public int EyeColor { get => eyeColor; set => eyeColor = value; }
    public int HairIndex { get => hairIndex; set => hairIndex = value; }
    public int HairColor { get => hairColor; set => hairColor = value; }
    public int MouthIndex { get => mouthIndex; set => mouthIndex = value; }
    public int NoseIndex { get => noseIndex; set => noseIndex = value; }
    public int OutfitIndex { get => outfitIndex; set => outfitIndex = value; }
    public int AccesoryIndex { get => accesoryIndex; set => accesoryIndex = value; }



    #endregion
    private void Awake()
    {
        instance = this;
    }


}
