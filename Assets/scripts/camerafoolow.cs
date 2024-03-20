using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camerafoolow : MonoBehaviour
{
    [SerializeField]Transform target;

    [SerializeField]Vector3 offset;
    [SerializeField]float time;
    [SerializeField]float t;


    Vector3 pos; 

    private void Update()
    {
        
        transform.LookAt(target.transform.position);
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, target.position + offset, t * Time.deltaTime), time * Time.deltaTime);

    }
}
