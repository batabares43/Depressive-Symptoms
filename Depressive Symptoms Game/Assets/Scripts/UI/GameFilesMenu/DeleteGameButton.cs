using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameButton : MonoBehaviour
{
    public void deleteSave() {
        MetaSaveLoad.Instance.deleteData(GetComponent<DataSaveContainer>().playerData);
        Destroy(gameObject);
    }
}
