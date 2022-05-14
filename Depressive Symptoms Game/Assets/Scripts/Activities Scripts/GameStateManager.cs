using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager instance;

    [Header("Variables de estado del juego")]
    [SerializeField] private string id;
    [SerializeField] private string namePlayer;
    [SerializeField] private int location = 0;
    [SerializeField] private bool isIdle;
    [SerializeField] private bool isInActivity;
    [SerializeField] private bool inSelection;
    [SerializeField] private bool isPaused;
    [SerializeField] private bool ableToMove;
    [SerializeField] private ActivityFunctions actualActivity;
    [SerializeField] private GameObject menuContinue;
    [SerializeField] private GameObject menuSelection;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject player;


    #region properties
    public bool IsIdle { get => isIdle; set { isIdle = value; changeAnimState(); } }
    public bool IsInActivity { get => isInActivity; set { isInActivity = value; changeAnimState(); } }
    public bool InSelection { get => inSelection; set => inSelection = value; }
    public bool IsPaused { get => isPaused; set { isPaused = value; InSelection = value; } }
    public bool AbleToMove { get => ableToMove; set => ableToMove = value; }
    public GameObject Player { get => player; set => player = value; }

    public ActivityFunctions ActualActivity { get => actualActivity; set => actualActivity = value; }

    public int Location { get => location; set => location = value; }

    public string Id { get => id; set => id = value; }
    public string Name { get => namePlayer; set => namePlayer = value; }
    public static GameStateManager Instance { get => instance; }
    #endregion


    public MetaData getMetaData()
    {
        MetaData d = new MetaData();
        d.id = id;
        d.name = namePlayer;
        d.location = location;
        return d;
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += instance.OnSceneLoaded;
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
    public void Save()
    {
        SaveContainer saveFile = new SaveContainer();
        saveFile.id = id;
        saveFile.player = PlayerLooks.Instance.GetPlayer();
        saveFile.time = TimeManager.Instance.GetTime();
        saveFile.variables = VarManager.Instance.GetVar();
        saveFile.control = ControlManager.Instance.GetControl();
        saveFile.record = RecordManager.Instace.GetRecords();
        GetComponent<SaveAndLoad>().save(saveFile, id);
    }
    public void load()
    {
        SaveContainer loadSave = GetComponent<SaveAndLoad>().load(id);
        GameStateManager.Instance.Id = loadSave.id;
        PlayerLooks.Instance.setPlayerLooks(loadSave.player);
        TimeManager.Instance.setTimeManager(loadSave.time);
        VarManager.Instance.setVarManager(loadSave.variables);
        ControlManager.Instance.setControlManager(loadSave.control);
        RecordManager.Instace.setRecordManager(loadSave.record);
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
