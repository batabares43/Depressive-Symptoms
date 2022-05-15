using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueActivity : MonoBehaviour
{
    public void finishActivity()
    {
        GameStateManager.Instance.ActualActivity.finishActivity();
        RecordManager.Instace.endRepetition(true);
        GameObject.Destroy(gameObject);
    }
    public void continueActivity(){
        GameStateManager.Instance.ActualActivity.finishActivity();
        GameStateManager.Instance.ActualActivity.activateActivity();
        GameObject.Destroy(gameObject);
    }

}
