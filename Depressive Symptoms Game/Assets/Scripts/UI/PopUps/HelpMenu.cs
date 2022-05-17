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

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            
            GameStateManager.Instance.InSelection = true;
            GameStateManager.Instance.AbleToMove = false;
        }
    }
    public void close()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            GameStateManager.Instance.InSelection = false;
            GameStateManager.Instance.AbleToMove = true;
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
