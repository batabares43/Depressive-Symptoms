using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityFunctions : MonoBehaviour
{
    [SerializeField] private Activity activityParams;
    [SerializeField] private string animationName;
    [SerializeField] private Animator anim;
    [SerializeField] private List<ActivityBehavior> activityBehaviors;

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
        activateBehaviors();
    }
    public void finishActivity()
    {
        fillVars();
        finishBehaviors();
        GameStateManager.Instance.IsIdle = true;
        GameStateManager.Instance.AbleToMove = true;
        GameStateManager.Instance.InSelection = false;
    }

    private void fillVars()
    {
        Record r =new Record(activityParams);
        TimeManager.Instance.timeShift(activityParams);
        VarManager.Instance.modificated(activityParams);
        ControlManager.Instance.modificated(activityParams);
        RecordManager.Instace.addRecord(r);
    }
    public void playAnim()
    {
        anim.Play(animationName);
    }

    private void activateBehaviors() {
        if (activityBehaviors.Count > 0)
        {
            foreach (ActivityBehavior b in activityBehaviors)
            {
                b.activateActivity();
            }

        }
    }
    private void finishBehaviors() {
        if (activityBehaviors.Count > 0)
        {
            foreach (ActivityBehavior b in activityBehaviors)
            {
                b.finishActivity();
            }
        }
    }
}
