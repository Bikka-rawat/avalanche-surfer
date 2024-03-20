using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    [SerializeField] GameObject[] levels;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnrandomlevel()
    {
        int index = Random.Range(0, levels.Length);
        Debug.Log(index);
        Instantiate(levels[index], new Vector3(0, -196.5f, 1085f), levels[index].transform.rotation);
    }
}
