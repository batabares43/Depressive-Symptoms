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
        //GameStateManager.Instance.gameObject.GetComponent<SaveAndLoad>().save();
    }
    public void saveAndExit()
    {
        saveGame();
        SceneManager.LoadScene(0);
    }


}
