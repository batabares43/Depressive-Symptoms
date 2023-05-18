using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private bool debug;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (debug)
        {
            panel.SetActive(debug);
            debug = false;
        }
    }

    public void moodAnswer(int ans)
    {
        Debug.Log(ans);
        panel.SetActive(false);
    }
}
