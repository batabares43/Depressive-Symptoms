using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueActivity : MonoBehaviour
{
    public void finishActivity()
    {
        GameStateManager.Instance.CurrentActivity.finishActivity();
        RecordManager.Instace.endRepetition(true);
        GameObject.Destroy(gameObject);
    }
    public void continueActivity(){
        GameStateManager.Instance.CurrentActivity.finishActivity();
        GameStateManager.Instance.CurrentActivity.activateActivity();
        GameObject.Destroy(gameObject);
    }

}
