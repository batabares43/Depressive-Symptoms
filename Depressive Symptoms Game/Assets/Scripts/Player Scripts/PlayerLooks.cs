using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLooks : MonoBehaviour
{
    private static PlayerLooks instance;
    public static PlayerLooks Instance { get => instance; }
    public void setPlayerLooks(PlayerContainer p)
    {

    }
    public PlayerContainer GetPlayer()
    {
        PlayerContainer p = new PlayerContainer();
        return p;
    }
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            if (instance != null && instance != this)
            {
                instance.gameObject.transform.position = gameObject.transform.position;
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                SceneManager.sceneLoaded += instance.OnSceneLoaded;
            }
        }
   
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "Main Menu")
        {

            try
            {
                SceneManager.sceneLoaded -= instance.OnSceneLoaded;
                Destroy(instance.gameObject);
                instance = null;

            }
            catch
            {
            }
        }
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= instance.OnSceneLoaded;
    }
}
