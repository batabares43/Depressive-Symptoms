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

    }
    public PlayerContainer GetPlayer()
    {
        PlayerContainer p = new PlayerContainer();
        return p;
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
        SceneManager.sceneLoaded -= instance.OnSceneLoaded;
    }
}
