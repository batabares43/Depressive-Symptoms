using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaves : MonoBehaviour
{
    [SerializeField]private GameObject content;
    [SerializeField] private GameObject fileView;
    private void OnEnable()
    {
        foreach (MetaData s in MetaSaveLoad.Instance.MetaData.listSaves)
        {
            GameObject currentFileView = Instantiate(fileView, content.transform);
            Debug.Log("Saves: "+JsonUtility.ToJson(s));
            currentFileView.GetComponent<DataSaveContainer>().putData(s);
        }
    }
    private void Update()
    {
        if(MetaSaveLoad.Instance.MetaData.count == 0)
        {
            gameObject.SetActive(false);
        }
        
    }
}
