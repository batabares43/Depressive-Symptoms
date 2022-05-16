using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrickActivation : MonoBehaviour
{
    [SerializeField] private GameObject trick;
    [SerializeField] private TMP_InputField input;
    private bool isActive;
    private bool isHolding;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isHolding = true;
        }
        if (isHolding)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isActive = !isActive;
                trick.SetActive(isActive);
                input.text = Application.persistentDataPath + "\\saves\\";
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isHolding = false;
        }
    }
}
