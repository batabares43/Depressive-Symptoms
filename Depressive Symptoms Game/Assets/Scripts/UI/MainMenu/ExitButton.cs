using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
#if UNITY_WEBPLAYER
     public static string webplayerQuitURL = "https://mrparadax.itch.io/one-week";
#endif
    public void exitGame()
    {

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
        #else
         Application.Quit();
        #endif

    }
}
