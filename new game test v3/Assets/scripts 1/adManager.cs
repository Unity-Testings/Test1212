using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adManager : MonoBehaviour
{
    private bool canContinue=false;
    public GameObject pannel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale < 1 && canContinue)
        {
            Time.timeScale += .001f;
            if(Time.timeScale>=1f)
            {
                canContinue = false;
                Time.timeScale = 1f;
            }
        }
    }

    public void continueButton()
    {
        canContinue = true;
        pannel.SetActive(false);
    }
}
