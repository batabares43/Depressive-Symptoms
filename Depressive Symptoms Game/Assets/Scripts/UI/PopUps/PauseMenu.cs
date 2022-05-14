using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
 

    public void pauseClose()
    {
        gameObject.SetActive(false);
    }
    public void saveGame() {
        GameStateManager.Instance.Save();
        MetaSaveLoad.Instance.updateData(GameStateManager.Instance.getMetaData());  
    }
    public void saveAndExit()
    {
        saveGame();
        SceneManager.LoadScene(0);
    }


}
