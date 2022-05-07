using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
   [SerializeField]private GameObject content;
   public void closeView()
    {
        foreach(Transform f in content.transform)
        {
            Destroy(f.gameObject);
        }
        gameObject.SetActive(false);
    }
}
