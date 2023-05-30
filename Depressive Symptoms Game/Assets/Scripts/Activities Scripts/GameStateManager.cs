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
    [SerializeField] private bool finishedWeek=false;
    [SerializeField] private bool cat = false;
    [SerializeField] private bool dog = false;
    [SerializeField] private bool work = false;
    [SerializeField] private bool study = false;
    [SerializeField] private bool isIdle;
    [SerializeField] private bool isInActivity;
    [SerializeField] private bool inSelection;
    [SerializeField] private bool isPaused;
    [SerializeField] private bool ableToMove;
    [SerializeField] private ActivityFunctions currentActivity;
    [SerializeField] private GameObject menuContinue;
    [SerializeField] private GameObject menuSelection;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject player;
    private Dictionary<string, int> status = new Dictionary<string, int>();

    #region properties
    public bool IsIdle { get => isIdle; set { isIdle = value; changeAnimState(); } }
    public bool IsInActivity { get => isInActivity; set { isInActivity = value; changeAnimState(); } }
    public bool InSelection { get => inSelection; set => inSelection = value; }
    public bool IsPaused { get => isPaused; set { isPaused = value; InSelection = value; } }
    public bool AbleToMove { get => ableToMove; set => ableToMove = value; }
    public GameObject Player { get => player; set => player = value; }

    public ActivityFunctions CurrentActivity { get => currentActivity; set => currentActivity = value; }

    public int Location { get => location; set => location = value; }
    public bool FinishedWeek { get => finishedWeek; set => finishedWeek = value; }

    public string Id { get => id; set => id = value; }
    public string Name { get => namePlayer; set => namePlayer = value; }
    public bool Cat { get => cat; set => cat = value; }
    public bool Dog { get => dog; set => dog = value; }
    public bool Work { get => work; set => work = value; }
    public bool Study { get => study; set => study = value; }
    public static GameStateManager Instance { get => instance; }
    public Dictionary<string, int> Status { get => status; }
    #endregion


    public MetaData getMetaData()
    {
        MetaData d = new MetaData();
        d.id = id;
        d.name = namePlayer;
        d.location = location;
        d.finishedWeek = finishedWeek;
        d.cat = cat;
        d.dog = dog;
        d.work = work;
        d.study = study;
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
            GetComponent<PauseStart>().PauseMenu = GameObject.Find("Pause");
            GameObject.Find("Pause").SetActive(false);
            GetComponent<FinishWeek>().Target = GameObject.Find("FinishWeek");
            GameObject.Find("FinishWeek").SetActive(false);
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
            currentActivity.playAnim();
            currentActivity.fillVars();
            if (currentActivity.ActivityParams.repetitive)
            {
                Instantiate(menuContinue, GameObject.Find("Canvas").transform);
            }
            else
            {
                currentActivity.finishActivity();
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
        saveFile.status = getStatusFromDict();
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
        setDictFromStatus(loadSave.status);
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
                Destroy(instance.gameObject);
                instance = null;

            }
            catch
            {
            }
            return;
        }
        if(scene.buildIndex != location)
        {
            Debug.Log("Level loaded: " + scene.buildIndex + " former level: " + location);
            location = scene.buildIndex;
            GetComponent<PauseStart>().PauseMenu = GameObject.Find("Pause");
            GameObject.Find("Pause").SetActive(false);
            GetComponent<FinishWeek>().Target = GameObject.Find("FinishWeek");
            GameObject.Find("FinishWeek").SetActive(false);
            GameStateManager.Instance.InSelection = false;
            GameStateManager.Instance.AbleToMove = true;
            player.GetComponent<PlayerMovementController>().playerStop();

        }

    }
    void OnDisable()
    {
        if (this == instance)
        {
            SceneManager.sceneLoaded -= instance.OnSceneLoaded;
        }
    }

    private StatusContainer getStatusFromDict()
    {
        StatusContainer statusContainer = new StatusContainer();
        statusContainer.statusOwner.Clear();
        statusContainer.state.Clear();
        foreach (KeyValuePair<string, int> pair in status)
        {
            statusContainer.statusOwner.Add(pair.Key);
            statusContainer.state.Add(pair.Value);
        }
        return statusContainer;
    }

    private void setDictFromStatus(StatusContainer savedStatus)
    {
        status.Clear();
        if (savedStatus.statusOwner.Count>0)
        {
            for (int i = 0; i < savedStatus.statusOwner.Count; i++)
            {
                status.Add(savedStatus.statusOwner[i], savedStatus.state[i]);
            }
        }
    }

}
