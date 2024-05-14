using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmovement : MonoBehaviour
{
    [SerializeField]float speed;
    Rigidbody rb;

    [SerializeField] GameObject objectToInstantiate;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(replaceobject());

    }

    IEnumerator replaceobject()
    {
        Terrain terrain = GetComponent<Terrain>();

        if (terrain != null)
        {

            TreeInstance[] treeInstances = terrain.terrainData.treeInstances;

            int count=0;
            foreach (TreeInstance treeInstance in treeInstances)
            {

                Vector3 worldPosition = Vector3.Scale(treeInstance.position, terrain.terrainData.size) + terrain.transform.position;


                Instantiate(objectToInstantiate, worldPosition, Quaternion.identity, transform);
                if (count == 50)
                {
                yield return new WaitForSeconds(0.01f);
                    count = 0;
                }
                count++;

            }
        }
        else
        {
            Debug.LogError("No active terrain found!");
        }
    }




    void FixedUpdate()
    {
        rb.MovePosition(rb.position + -transform.forward * speed * Time.fixedDeltaTime);
    }
}
