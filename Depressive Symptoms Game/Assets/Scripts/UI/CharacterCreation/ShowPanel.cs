using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> panel;

    public void togglePanel(int i)
    {
        for (int j= 0; j < panel.Count; j++)
        {
            if (j == i)
            {
                bool isActive = !panel[i].activeSelf;
                panel[i].SetActive(isActive);
            }
            else
            {
                panel[j].SetActive(false);
            }
        }
        
    }
}
