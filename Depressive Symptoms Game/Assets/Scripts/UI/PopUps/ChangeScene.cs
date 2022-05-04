using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{ 
   public void loadLevel(string level) {
        activePlayer();
        SceneManager.LoadScene(level);
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
