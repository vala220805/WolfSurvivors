using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Rewards
    {
        public GameObject itemPrefab;
        public int dropRate;
    }

    public List<Rewards> rewards;

    private void OnDestroy() 
    {
        float randItem = UnityEngine.Random.Range(0f, 100f);

        foreach (Rewards item in rewards)
        {
            if (randItem <= item.dropRate)
            {
                Instantiate(item.itemPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
