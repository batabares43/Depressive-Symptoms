using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveAndLoad:MonoBehaviour
{
    private string path;
    private void Start()
    {
        path = Application.persistentDataPath + "\\saves\\" + GameStateManager.Instance.Id + ".json";
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("Save")]
    public void save() {
        Debug.Log(Application.persistentDataPath);
        SaveContainer saveFile = new SaveContainer();
        saveFile.id = GameStateManager.Instance.Id;
        saveFile.location = GameStateManager.Instance.Location;
        saveFile.player=PlayerLooks.Instance.GetPlayer();
        saveFile.time = TimeManager.Instance.GetTime();
        saveFile.variables = VarManager.Instance.GetVar();
        saveFile.control = ControlManager.Instance.GetControl();
        saveFile.record = RecordManager.Instace.GetRecords();
        string json = JsonUtility.ToJson(saveFile);
        Debug.Log(json);
        File.WriteAllText(path, json);

    }
    [ContextMenu("Load")]
    public void load() {
        SaveContainer loadSave = new SaveContainer();
        loadSave = JsonUtility.FromJson<SaveContainer>(File.ReadAllText(path));
        GameStateManager.Instance.Id = loadSave.id;
        GameStateManager.Instance.Location = loadSave.location;
        PlayerLooks.Instance.setPlayerLooks(loadSave.player);
        TimeManager.Instance.setTimeManager(loadSave.time);
        VarManager.Instance.setVarManager(loadSave.variables);
        ControlManager.Instance.setControlManager(loadSave.control);
        RecordManager.Instace.setRecordManager(loadSave.record);
    }
}
