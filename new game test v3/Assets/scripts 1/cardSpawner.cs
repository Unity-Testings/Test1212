using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardSpawner : MonoBehaviour
{
    public float fireRate;
    public incomingCard _card;
    private float nextTimeToFire=0f;
    private float currentTime;
    private float nextUpgradeTime;
    public float increaseTimeBetweenWaves=5f;
    void Start()
    {
        currentTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time + Time.deltaTime >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Instantiate(_card,gameObject.transform);
        }
        if(currentTime>=nextUpgradeTime)
        {
            fireRate += fireRate*.05f;
            currentTime = Time.time;
            nextUpgradeTime = Time.time+increaseTimeBetweenWaves;
            increaseTimeBetweenWaves+=.5f;
        }
        else
        {
            currentTime += Time.deltaTime;
        }



    }
    
}
