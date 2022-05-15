using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityFunctions : MonoBehaviour
{
    [SerializeField] private Activity activityParams;
    [SerializeField] private string animationName;
    [SerializeField] private Animator anim;
    [SerializeField] private List<ActivityBehavior> activateBehaviors;
    [SerializeField] private List<ActivityBehavior> finishBehaviors;
    [SerializeField] private bool isActive=true;
    public bool IsActive { get=>isActive; set=>isActive=value; }


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
        onActivation();
    }
    public void finishActivity()
    {
        fillVars();
        onFinish();
        GameStateManager.Instance.IsIdle = true;
        GameStateManager.Instance.AbleToMove = true;
        GameStateManager.Instance.InSelection = false;
    }

    private void fillVars()
    {
        if (!activityParams.unrecorded)
        {
            Record r = new Record(activityParams);
            TimeManager.Instance.timeShift(activityParams);
            VarManager.Instance.modificated(activityParams);
            ControlManager.Instance.modificated(activityParams);
            RecordManager.Instace.addRecord(r);
        }
        
    }
    public void playAnim()
    {
        anim.Play(animationName);
    }

    private void onActivation() {
        if (activateBehaviors.Count > 0)
        {
            foreach (ActivityBehavior b in activateBehaviors)
            {
                b.activate();
            }

        }
    }
    private void onFinish() {
        if (finishBehaviors.Count > 0)
        {
            foreach (ActivityBehavior b in finishBehaviors)
            {
                b.activate();
            }
        }
    }
}
