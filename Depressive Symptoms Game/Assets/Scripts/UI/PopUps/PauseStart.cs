using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStart : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public GameObject PauseMenu { set => pauseMenu=value; }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool temp = !GameStateManager.Instance.IsPaused;
            GameStateManager.Instance.IsPaused = temp;
            GameStateManager.Instance.InSelection = temp;
            GameStateManager.Instance.AbleToMove = !temp;
            GameStateManager.Instance.IsIdle = !temp;
            pauseMenu.SetActive(temp);
        }
        
    }

}
