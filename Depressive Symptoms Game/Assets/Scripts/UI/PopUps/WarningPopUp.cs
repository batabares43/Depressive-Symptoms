using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPopUp : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    public void close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
