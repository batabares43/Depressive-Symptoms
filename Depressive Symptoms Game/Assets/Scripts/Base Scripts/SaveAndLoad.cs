using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveAndLoad:MonoBehaviour
{
    private string path;

 

    [ContextMenu("Save")]
    public void save() {
        path = Application.persistentDataPath + "\\saves\\" + GameStateManager.Instance.Id + ".json";
        SaveContainer saveFile = new SaveContainer();
        saveFile.id = GameStateManager.Instance.Id;
        saveFile.player=PlayerLooks.Instance.GetPlayer();
        saveFile.time = TimeManager.Instance.GetTime();
        saveFile.variables = VarManager.Instance.GetVar();
        saveFile.control = ControlManager.Instance.GetControl();
        saveFile.record = RecordManager.Instace.GetRecords();
        string json = JsonUtility.ToJson(saveFile);
        Debug.Log(json);
        Debug.Log(path);
        File.WriteAllText(path, json);

    }
    [ContextMenu("Load")]
    public void load() {
        path = Application.persistentDataPath + "\\saves\\" + GameStateManager.Instance.Id + ".json";
        SaveContainer loadSave = new SaveContainer();
        loadSave = JsonUtility.FromJson<SaveContainer>(File.ReadAllText(path));
        GameStateManager.Instance.Id = loadSave.id;
        PlayerLooks.Instance.setPlayerLooks(loadSave.player);
        TimeManager.Instance.setTimeManager(loadSave.time);
        VarManager.Instance.setVarManager(loadSave.variables);
        ControlManager.Instance.setControlManager(loadSave.control);
        RecordManager.Instace.setRecordManager(loadSave.record);
    }
}
