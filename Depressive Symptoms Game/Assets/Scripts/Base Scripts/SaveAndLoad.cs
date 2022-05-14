using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveAndLoad:MonoBehaviour
{
    [SerializeField]private string path;

 

    [ContextMenu("Save")]
    public void save(SaveContainer saveFile, string id) {
        path = Application.persistentDataPath + "\\saves\\" + id + ".json";
        string json = JsonUtility.ToJson(saveFile);
        File.WriteAllText(path, json);

    }
    [ContextMenu("Load")]
    public SaveContainer load(string id) {
        path = Application.persistentDataPath + "\\saves\\" + id + ".json";
        SaveContainer loadSave = new SaveContainer();
        loadSave = JsonUtility.FromJson<SaveContainer>(File.ReadAllText(path));
        return loadSave;
    }
}
