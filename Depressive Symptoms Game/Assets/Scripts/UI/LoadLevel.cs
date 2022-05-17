using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    private static LoadLevel instance;
    public static LoadLevel Instance { get=>instance;}

    [SerializeField] private GameObject target;
    private Slider bar;
    private void Awake()
    {
        if(instance!=null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        
    }
    public void loadingLevel(int i)
    {
        
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            GameStateManager.Instance.InSelection = true;
            GameStateManager.Instance.AbleToMove = false;
        }
        bar = Instantiate(target, GameObject.Find("Canvas").transform).GetComponent<LoadBarContainer>().bar;
        StartCoroutine(loadingLevelAsync(i));

    }

    IEnumerator loadingLevelAsync(int i)
    {
        AsyncOperation levelLoad = SceneManager.LoadSceneAsync(i);
        while (!levelLoad.isDone)
        {
            float p = levelLoad.progress / .9f;
            bar.value = p;
            yield return null;
        }
    }
    public void loadingLevel(string i)
    {

        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            GameStateManager.Instance.InSelection = true;
            GameStateManager.Instance.AbleToMove = false;
        }
        bar = Instantiate(target, GameObject.Find("Canvas").transform).GetComponent<LoadBarContainer>().bar;
        StartCoroutine(loadingLevelAsync(i));

    }

    IEnumerator loadingLevelAsync(string i)
    {
        AsyncOperation levelLoad = SceneManager.LoadSceneAsync(i);
        while (!levelLoad.isDone)
        {
            float p = levelLoad.progress / .9f;
            bar.value = p;
            yield return null;
        }
    }
}
