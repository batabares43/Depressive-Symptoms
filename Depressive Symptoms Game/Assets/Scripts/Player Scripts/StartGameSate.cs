using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameSate : MonoBehaviour
{
    void Start()
    {
        GameStateManager.Instance.Name = PathScript.Instance.NamePlayer;
        if (PathScript.Instance.FirstTime)
        {
            GameStateManager.Instance.Id =MetaSaveLoad.Instance.createData(GameStateManager.Instance.getMetaData());
            insertPlayerData();
        }
        else
        {
            GameStateManager.Instance.Id = PathScript.Instance.Id;
            loadData();
        }
        Destroy(PathScript.Instance.gameObject);

    }
    private void insertPlayerData()
    {
        PlayerLooks.Instance.setPlayerLooks(PlayerData.Instance.getPlayerData());
        saveData();
    }

    private void saveData()
    {
        GetComponent<SaveAndLoad>().save();
    }

    private void loadData()
    {
        GetComponent<SaveAndLoad>().load();
    }
}
