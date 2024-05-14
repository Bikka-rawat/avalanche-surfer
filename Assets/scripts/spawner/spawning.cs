using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    [SerializeField] GameObject[] levels;
    [SerializeField] Transform spawnpoint;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnrandomlevel()
    {
        int index = Random.Range(0, levels.Length);
        Debug.Log(index);
        Instantiate(levels[index], spawnpoint.position, levels[index].transform.rotation);
    }
}
