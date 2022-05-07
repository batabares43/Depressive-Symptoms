using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreationStartGameButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField]private bool validated = false;

    public void startGame()
    {
        validateName();
        if (validated)
        {
            PathScript.Instance.FirstTime = true;
            PathScript.Instance.Id = "";
            PathScript.Instance.NamePlayer = nameInput.text.Trim();
            PathScript.Instance.Location = 1;
            SceneManager.LoadScene(PathScript.Instance.Location);
        }

    }
     private void validateName()
    {
        nameInput.text = nameInput.text.Trim();
        print("["+ nameInput.text + "]");
        for (int i = 0; i < nameInput.text.Length; i++)
        {
            if (nameInput.text[i] != ' ')
            {
                
                validated = true;
            }

        }
        if (nameInput.text.Length>1 && nameInput.text.Length<=50)
        {
            validated = true;
        }
        else
        {
            validated = false;
        }
    }

    
    
}
