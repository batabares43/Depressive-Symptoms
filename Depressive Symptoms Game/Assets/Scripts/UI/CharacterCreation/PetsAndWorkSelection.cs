using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetsAndWorkSelection : MonoBehaviour
{
    [SerializeField] private GameObject selectMenu;
    [SerializeField] private Image catButton;
    [SerializeField] private Image dogButton;
    [SerializeField] private Image workButton;
    [SerializeField] private Image studyButton;
    [SerializeField] private Sprite truebutton;
    [SerializeField] private Sprite falseButton;
    [SerializeField] private Color greenColor;
    [SerializeField] private Color redColor;

    private void OnEnable()
    {
        PathScript.Instance.Cat = false;
        changeColor(catButton, false);
        PathScript.Instance.Dog = false;
        changeColor(dogButton, false);
        PathScript.Instance.Dog = false;
        changeColor(catButton, false);
        PathScript.Instance.Work = false;
        changeColor(workButton, false);
        PathScript.Instance.Study = false;
        changeColor(studyButton, false);
    }

    private void changeColor(Image button, bool state) {
        if (state)
        {
            button.sprite = truebutton;
            button.color = greenColor;
        }
        else
        {
            button.sprite = falseButton;
            button.color = redColor;
        }
    }

    public void Toggle(int i) {
        bool newState;
        if (i == 1)
        {
            newState = !PathScript.Instance.Cat;
            PathScript.Instance.Cat = newState;
            changeColor(catButton, newState);
        }
        else if(i == 2)
        {
            newState = !PathScript.Instance.Dog;
            PathScript.Instance.Dog = newState;
            changeColor(dogButton, newState);
        }
        else if (i == 3)
        {
            newState = !PathScript.Instance.Work;
            PathScript.Instance.Work = newState;
            changeColor(workButton, newState);
        }
        else if (i == 4)
        {
            newState = !PathScript.Instance.Study;
            PathScript.Instance.Study = newState;
            changeColor(studyButton, newState);
        }
    
        
    }
    public void closeMenu()
    {
        selectMenu.SetActive(false);
    }
    public void openMenu()
    {
        selectMenu.SetActive(true);
    }
}
