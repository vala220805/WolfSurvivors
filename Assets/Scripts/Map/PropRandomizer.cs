using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;
    void Start()
    {
        SpawnProps();
    }

    void SpawnProps()
    {
        foreach (GameObject point in propSpawnPoints)
        {
            int randomizer = Random.Range(0, propPrefabs.Count);
            GameObject prop = Instantiate(propPrefabs[randomizer], point.transform.position, Quaternion.identity);
            prop.transform.parent = point.transform;
        }
    }
}
