using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateMenu : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject master;
    [SerializeField] private Text label;

    public void buildMenu(GameObject target,List<ActivityFunctions> activities)
    {
        master = target;
        label.text = master.name;
        foreach(ActivityFunctions a in activities)
        {
            GameObject currentButton = Instantiate(button, content.transform);
            currentButton.GetComponent<SelectedActivity>().buildButton(a, gameObject);
        }
    }
}
