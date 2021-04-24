using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepActivity : ActivityController
{
    [SerializeField] private GameObject menu;
    public override void activate()
    {
        Debug.Log("spleeping");
        menu.SetActive(true);

    }

    public override void endActivity()
    {
        ended = true;
        menu.SetActive(false);
    }



    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
