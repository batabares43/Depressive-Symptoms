using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateMenu : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject master;
    [SerializeField] private TextMeshProUGUI label;

    public void buildMenu(GameObject target,List<ActivityFunctions> activities)
    {
        GameStateManager.Instance.InSelection = true;
        master = target;
        label.SetText(master.name);
        foreach (ActivityFunctions a in activities)
        {
            GameObject currentButton = Instantiate(button, content.transform);
            currentButton.GetComponent<SelectedActivity>().buildButton(a, gameObject);
        }
    }

    public void exitMenu()
    {
        GameStateManager.Instance.InSelection = false;
        GameStateManager.Instance.AbleToMove = true;
        Destroy(gameObject);
    }
}
