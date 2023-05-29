using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VersionUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        text.text = "V. " + Application.version;
    }
}
