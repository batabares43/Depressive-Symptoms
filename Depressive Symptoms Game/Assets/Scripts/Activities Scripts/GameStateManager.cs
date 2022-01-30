using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager instance;

    [Header("Variables de estado del juego")]
    [SerializeField] private bool isIdle;
    [SerializeField] private bool isInActivity;
    [SerializeField] private bool inSelection;
    [SerializeField] private bool isPaused;
    [SerializeField] private bool ableToMove;
    [SerializeField] private ActivityFunctions actualActivity;
    [SerializeField] private GameObject menuContinue;
    [SerializeField] private GameObject menuSelection;
    [SerializeField]private Animator anim;
    [SerializeField] private GameObject player;
    

    #region properties
    public bool IsIdle { get => isIdle; set  { isIdle = value; changeAnimState(); } }
    public bool IsInActivity { get=> isInActivity; set { isInActivity = value;changeAnimState(); } }
    public bool InSelection { get => inSelection; set => inSelection=value; }
    public bool IsPaused { get=> isPaused; set { isPaused = value; InSelection = value; } }
    public bool AbleToMove { get => ableToMove; set => ableToMove = value; }
    public GameObject Player { get => player; set => player = value; }

    public ActivityFunctions ActualActivity { get => actualActivity; set => actualActivity = value; }

    public static GameStateManager Instance { get => instance; }
    #endregion

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        ableToMove = true;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }
    private void Update()
    {
        if (isInActivity)
        {
            checkActivityFinished();
        }
    }
    private void changeAnimState()
    {
        anim.SetBool("IsIdle", isIdle);
        anim.SetBool("InActivity", isInActivity);
    }
    private void checkActivityFinished()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Finished"))
        {
            IsInActivity = false;
            actualActivity.playAnim();
            if (actualActivity.ActivityParams.repetitive)
            {
                Instantiate(menuContinue, GameObject.Find("Canvas").transform);
            }
            else
            {
                ActualActivity.finishActivity();
            }
        }
    }
    public void showSelectionMenu(GameObject target, List<ActivityFunctions> a)
    {
        GameObject menu = Instantiate(menuSelection, GameObject.Find("Canvas").transform);
        menu.GetComponent<GenerateMenu>().buildMenu(target, a);
    }
}
