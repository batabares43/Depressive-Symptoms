using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskMenu : MonoBehaviour,Observer
{
    [SerializeField] private GameObject panel;
    [SerializeField] public bool showQuestion;
    [SerializeField] public int currentDay = -1;
    [SerializeField] private string statusKey;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        TimeManager.Instance.suscribe(this);
    }

    public void moodAnswer(int ans)
    {
        Debug.Log(ans);
        VarManager.Instance.Mood = ans;
        GameStateManager.Instance.InSelection = false;
        GameStateManager.Instance.AbleToMove = true;
        panel.SetActive(false);
    }

    public void updateState()
    {
        int newDay = TimeManager.Instance.Day;
        if(currentDay == -1 && GameStateManager.Instance.Status.ContainsKey(statusKey))
        {
            int i = GameStateManager.Instance.Status[statusKey];
            if(i == 1)
            {
                showQuestion = true;
            }
            else if (i==2)
            {
                showQuestion = false;
            }
            currentDay = newDay;
        }
        if(currentDay != newDay)
        {
            GameStateManager.Instance.Status[statusKey] = 1;
            showQuestion = true;
            currentDay = newDay;
        }

    }

    private void Update()
    {
        if (showQuestion && GameStateManager.Instance.AbleToMove) 
        {
            GameStateManager.Instance.Status[statusKey] = 2;
            panel.SetActive(showQuestion);
            GameStateManager.Instance.InSelection = true;
            GameStateManager.Instance.AbleToMove = false;
            showQuestion = false;
        }
    }
    public void unSuscribe()
    {
        TimeManager.Instance.deSuscribe(this);
    }

    private void OnDestroy()
    {
        unSuscribe();
    }
}
