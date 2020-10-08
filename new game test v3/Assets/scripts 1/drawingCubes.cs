using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawingCubes : MonoBehaviour
{
    public bool isOn = false;
    public int previousState = -1;
    void Start()
    {
        
    }

    void Update()
    {

    }
    /*private void OnMouseEnter()
    {
        isOn = !isOn;
        if(isOn)
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        else
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        Debug.Log("yes");
    }*/
    public void resetCube()
    {
        isOn = false;
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
