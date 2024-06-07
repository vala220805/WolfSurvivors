using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemReward : MonoBehaviour, ICollectible
{
    public float healthAmount;
    public void Collect()
    {
        PlayerStats playerStats= FindObjectOfType<PlayerStats>();
        playerStats.IncreaseHealth(healthAmount);
        Destroy(gameObject);
    }
}
