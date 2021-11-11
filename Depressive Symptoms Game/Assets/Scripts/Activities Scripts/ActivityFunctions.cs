using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityFunctions : MonoBehaviour
{
    [SerializeField] private Activity activityParams;
    [SerializeField] private bool isAA;
    [SerializeField] private string animationName;
    [SerializeField] private Animator anim;

    public Activity ActivityParams { get => activityParams; }
    private void Start()
    {
        anim=GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    [ContextMenu("AA")]
    public void activateActivity()
    {
        GameStateManager.Instance.IsIdle = false;
        GameStateManager.Instance.IsInActivity = true;
        GameStateManager.Instance.InSelection = true;
        GameStateManager.Instance.AbleToMove = false;
        GameStateManager.Instance.ActualActivity = this;
        GameStateManager.Instance.Player.transform.position = new Vector2(transform.position.x, GameStateManager.Instance.Player.transform.position.y);
        GameStateManager.Instance.Player.transform.localScale = new Vector3(1, 1, 1);
        playAnim();

    }
    public void finishActivity()
    {
        fillVars();
        GameStateManager.Instance.IsIdle = true;
        GameStateManager.Instance.AbleToMove = true;
        GameStateManager.Instance.InSelection = false;
    }

    private void fillVars()
    {
        Record r =new Record();
        r = TimeManager.Instance.timeShift(r, activityParams.time);
        r = VarManager.Instance.modificated(r, activityParams.mood, 0, activityParams.sleepHours, 0, activityParams.energy, 0, 0, 0, 0, 0);
        r = ControlManager.Instance.modificated(r, activityParams.hygiene, 0, 0, 0, 0, activityParams.satiety, activityParams.rest, activityParams.bladder, activityParams.entertainment, 0);
        r = new Record();
        r.nameActivity = activityParams.nameActivity;
        RecordManager.Instace.addRecord(r);
    }
    public void playAnim()
    {
        anim.Play(animationName);
    }
}
