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
        GameStateManager.Instance.ActualActivity = this;
        GameStateManager.Instance.Player.transform.localScale = new Vector3(1, 1, 1);
        playAnim();

    }
    public void finishActivity()
    {
        fillVars();
        GameStateManager.Instance.IsIdle = true;
    }

    private void fillVars()
    {
        Debug.Log("Aqui se llenan las variables, ya vere como lo hare");
    }
    public void playAnim()
    {
        anim.Play(animationName);
    }
}
