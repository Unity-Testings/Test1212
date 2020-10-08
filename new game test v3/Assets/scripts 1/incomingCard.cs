using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incomingCard : MonoBehaviour
{
    public GameObject[] _cubes;
    public int[] theCard;
    public float speed=2;
    public Material fadedWhiteMaterial;
    public Animation anim;

    void Start()
    {
        speed = -speed;
        theCard = new int [_cubes.Length];

        for(int i=0; i<_cubes.Length; i++)
        {
            theCard[i] = Random.Range(0, 2);
            if(theCard[i] == 0)
            {
                _cubes[i].GetComponent<MeshRenderer> ().material = fadedWhiteMaterial;
            }
            

        }

        //Debug.Log(theCard[0].ToString() + theCard[1].ToString() + theCard[2].ToString() + theCard[3].ToString() + theCard[4].ToString() + theCard[5].ToString() + theCard[6].ToString() + theCard[7].ToString() + theCard[8].ToString());
        
    }

    void Update()
    {
 
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collider entered");
    }
}
