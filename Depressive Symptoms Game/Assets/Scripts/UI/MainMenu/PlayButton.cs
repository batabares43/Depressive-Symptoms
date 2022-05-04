using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] public bool gameFiles = false;
    [SerializeField] private GameObject gameFilesMenu;
    [SerializeField] private GameObject characterCreationMenu;
    [SerializeField] private string path;

    private void Awake()
    {
        path = Application.persistentDataPath + "\\saves\\";
    }

    public void playGame()
    {
        loadMeta();
        if (gameFiles)
        {
            gameFilesMenu.SetActive(true);
        }
        else
        {
            characterCreationMenu.SetActive(true);
        }
    }
    private void loadMeta()
    {
        MetaContainer metaData;
        try
        {
            metaData = JsonUtility.FromJson<MetaContainer>(File.ReadAllText(path+ "saves.json"));
            if (metaData.count == 0)
            {
                gameFiles = false;
            }
            Debug.Log("it works");
        }
        catch
        {
            Debug.LogError("this file doesn't exist");
            Debug.Log(path);
            metaData = new MetaContainer();
            metaData.listSaves = new List<MetaData>();
            string json = JsonUtility.ToJson(metaData);
            Directory.CreateDirectory(path);
            File.WriteAllText(path + "saves.json", json);
            loadMeta();
        }

    }

    
}
