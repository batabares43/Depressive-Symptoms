using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameSate : MonoBehaviour
{
    [SerializeField] private GameObject view;
    void Start()
    {
        try
        {
            GameStateManager.Instance.Name = PathScript.Instance.NamePlayer;
            GameStateManager.Instance.FinishedWeek= PathScript.Instance.FinishedWeek;
            if (PathScript.Instance.FirstTime)
            {
                GameStateManager.Instance.Id = MetaSaveLoad.Instance.createData(GameStateManager.Instance.getMetaData());
                insertPlayerData();
                Instantiate(view, GameObject.Find("Canvas").transform);
            }
            else
            {
                GameStateManager.Instance.Id = PathScript.Instance.Id;
                GameStateManager.Instance.InSelection = false;
                GameStateManager.Instance.AbleToMove = true;
                loadData();
            }
            Destroy(PathScript.Instance.gameObject);
        }
        catch { }
        
    }
    private void insertPlayerData()
    {
        PlayerLooks.Instance.setPlayerLooks(PlayerData.Instance.getPlayerData());
        saveData();
    }

    private void saveData()
    {
        GameStateManager.Instance.Save();
    }

    private void loadData()
    {
        GameStateManager.Instance.load();
    }
}
