using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStart : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            GameStateManager.Instance.IsPaused = true;
            GameStateManager.Instance.AbleToMove = false;
            GameStateManager.Instance.IsIdle = false;
        }
        
    }
}
