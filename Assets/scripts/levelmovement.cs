using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;

    [SerializeField] GameObject objectToInstantiate;
    List<Vector3> positionsToInstantiate = new List<Vector3>(); // Store world positions here

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Run the task to prepare object positions in a separate thread
        Task.Run(() => PrepareObjectsToInstantiate());
    }

    async Task PrepareObjectsToInstantiate()
    {
        Terrain terrain = GetComponent<Terrain>();

        if (terrain != null)
        {
            TreeInstance[] treeInstances = terrain.terrainData.treeInstances;

            foreach (TreeInstance treeInstance in treeInstances)
            {
                Vector3 worldPosition = Vector3.Scale(treeInstance.position, terrain.terrainData.size) + terrain.transform.position;
                lock (positionsToInstantiate) // Make sure the list is thread-safe
                {
                    positionsToInstantiate.Add(worldPosition);
                }

                // To avoid blocking, introduce a small delay
                await Task.Yield();
            }

            // Once all positions are prepared, start instantiation on the main thread
            StartCoroutine(InstantiateObjects());
        }
        else
        {
            Debug.LogError("No active terrain found!");
        }
    }

    IEnumerator InstantiateObjects()
    {
        int count = 0;

        while (positionsToInstantiate.Count > 0)
        {
            Vector3 position;

            lock (positionsToInstantiate)
            {
                if (positionsToInstantiate.Count == 0)
                    yield break; // No more positions to instantiate

                position = positionsToInstantiate[0];
                positionsToInstantiate.RemoveAt(0);
            }

            Instantiate(objectToInstantiate, position, Quaternion.identity, transform);

            count++;

            // Limit instantiation to batches to avoid a heavy load on a single frame
            if (count >= 10)
            {
                count = 0;
                yield return null; // Pause the coroutine and continue next frame
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + -transform.forward * speed * Time.fixedDeltaTime);
    }
}