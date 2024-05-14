using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacledetroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Snowman"))
        {

        Destroy(other.gameObject,5f);
        }
    }
}
