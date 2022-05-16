using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] welcomePanels;
    [SerializeField] private GameObject[] tutorialPanels;
    private bool isWelcome = true;
    private int indexWelcome;
    private int indexTutorial;

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            GameStateManager.Instance.InSelection = true;
        }
    }
    public void close()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            GameStateManager.Instance.InSelection = false;
        }
        Destroy(gameObject);
    }

    public void changePanels()
    {
        isWelcome = !isWelcome;
        welcomePanels[indexWelcome].SetActive(isWelcome);
        tutorialPanels[indexTutorial].SetActive(!isWelcome);
        
    }
    public void nextPanel()
    {
        if (isWelcome)
        {
            welcomePanels[indexWelcome].SetActive(false);
            indexWelcome++;
            welcomePanels[indexWelcome].SetActive(true);
        }
        else
        {
            tutorialPanels[indexTutorial].SetActive(false);
            indexTutorial++;
            tutorialPanels[indexTutorial].SetActive(true);
        }
    }
    public void previousPanel()
    {
        if (isWelcome)
        {
            welcomePanels[indexWelcome].SetActive(false);
            indexWelcome--;
            welcomePanels[indexWelcome].SetActive(true);
        }
        else
        {
            tutorialPanels[indexTutorial].SetActive(false);
            indexTutorial--;
            tutorialPanels[indexTutorial].SetActive(true);
        }
    }
}
