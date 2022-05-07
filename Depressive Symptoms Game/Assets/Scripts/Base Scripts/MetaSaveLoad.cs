using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MetaSaveLoad : MonoBehaviour
{
    private static MetaSaveLoad instance;
    private MetaContainer metaData;
    [SerializeField] private string path;

    public MetaContainer MetaData { get=>metaData; set=>metaData=value; }
    public static MetaSaveLoad Instance { get => instance;}
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            path = Application.persistentDataPath + "\\saves\\";
        }
    }


    public string createData(MetaData d)
    {
        if (metaData == null)
        {
            loadMeta();
            Debug.Log(JsonUtility.ToJson(metaData));
            return createData(d);
        }
        else
        {
            string id;
            bool isNewId = false;
            while (!isNewId)
            {
                id = Guid.NewGuid().ToString();
                d.id = id;
                isNewId = true;
                foreach (MetaData s in metaData.listSaves)
                {
                    if (s.id.Equals(d.id))
                    {
                        isNewId = false;
                    }
                }
            }
            metaData.listSaves.Add(d);
            metaData.count = metaData.listSaves.Count;
            saveData();
            return d.id;
        }
        
    }
    public void updateData(MetaData d) {
        if (metaData == null)
        {
            loadMeta();
            updateData(d);
        }
        else
        {
            foreach (MetaData s in metaData.listSaves)
            {
                if (s.id.Equals(d.id))
                {
                    s.id = d.id;
                    s.name = d.name;
                    s.location = d.location;
                }
            }
            saveData();
        }
        
    }
    public void deleteData(MetaData d) {
        if (metaData == null)
        {
            loadMeta();
            deleteData(d);
        }
        else
        {
            metaData.listSaves.Remove(d);
            File.Delete(path + d.id + ".json");
            metaData.count = metaData.listSaves.Count;
            saveData();
        }  
    }
    public void saveData()
    {
        string json = JsonUtility.ToJson(metaData);
        Debug.Log(json);
        File.WriteAllText(path + "saves.json", json);
    }
    public void loadMeta()
    {
        try
        {

            metaData = JsonUtility.FromJson<MetaContainer>(File.ReadAllText(path + "saves.json"));
        }
        catch
        {
            metaData = new MetaContainer();
            metaData.listSaves = new List<MetaData>();
            string json = JsonUtility.ToJson(metaData); 
            Directory.CreateDirectory(path);
            File.WriteAllText(path + "saves.json", json);
            loadMeta();
        }

    }

    public void clearData()
    {
        metaData = null;
    }
}
