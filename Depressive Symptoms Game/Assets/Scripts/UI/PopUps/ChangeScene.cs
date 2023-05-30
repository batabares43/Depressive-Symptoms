using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> buttons;

    private void OnEnable()
    {
        buttons[1].SetActive(GameStateManager.Instance.Study);
        buttons[2].SetActive(GameStateManager.Instance.Work);
        buttons[GameStateManager.Instance.Location-1].SetActive(false);
    }
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
