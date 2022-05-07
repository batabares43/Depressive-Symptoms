using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject gameFilesMenu;
    [SerializeField] private GameObject characterCreationMenu;

    
    public void playGame()
    {
        MetaSaveLoad.Instance.loadMeta();
        if (MetaSaveLoad.Instance.MetaData.count>0)
        {
            gameFilesMenu.SetActive(true);
        }
        else
        {
            characterCreationMenu.SetActive(true);
        }
    }
    

    
}
