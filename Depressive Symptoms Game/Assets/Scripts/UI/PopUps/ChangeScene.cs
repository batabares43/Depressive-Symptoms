using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{ 
   public void loadLevel(string level) {
        activePlayer();
        LoadLevel.Instance.loadingLevel(level);
    }
   public void closeWindow()
    {
        gameObject.SetActive(false);
        activePlayer();
    }
    private void activePlayer()
    {
        GameStateManager.Instance.IsIdle = true;
        GameStateManager.Instance.AbleToMove = true;
        GameStateManager.Instance.InSelection = false;
    }
}
