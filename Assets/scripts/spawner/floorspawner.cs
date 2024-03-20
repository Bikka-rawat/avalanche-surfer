using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorspawner : MonoBehaviour
{

    public spawning spawningsc;



  
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            spawnfloor();
        }
    }

    void spawnfloor()
    {
        spawningsc.spawnrandomlevel();
    }
}
