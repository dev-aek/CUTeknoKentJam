using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShower : MonoBehaviour
{
    public GameObject prefab; 
    public Transform spawnPoint; 
    public Transform targetPoint; 
    public int maxPrefabs = 20; 
    public float spawnInterval = 1f; 

    private List<GameObject> prefabs = new List<GameObject>();
    private int prefabIndex = 0;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPrefab), 0f, spawnInterval);
    }

    private void SpawnPrefab()
    {
        GameObject instance;
        if (prefabs.Count < maxPrefabs)
        {
            instance = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            prefabs.Add(instance);
        }
        else
        {
            instance = prefabs[prefabIndex];
            instance.transform.position = spawnPoint.position;
            instance.transform.rotation = spawnPoint.rotation;
            instance.SetActive(true);
            prefabIndex = (prefabIndex + 1) % maxPrefabs;
        }

        instance.GetComponent<MovingPrefab>().target = targetPoint;
    }
}
