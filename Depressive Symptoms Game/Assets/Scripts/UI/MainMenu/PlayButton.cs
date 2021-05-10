using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] public bool gameFiles = false;
    [SerializeField] private GameObject gameFilesMenu;
    [SerializeField] private GameObject characterCreationMenu;
    
    public void playGame()
    {
        if (gameFiles)
        {
            gameFilesMenu.SetActive(true);
        }
        else
        {
            characterCreationMenu.SetActive(true);
        }
    }


    
}
