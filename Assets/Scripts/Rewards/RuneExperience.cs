using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneExperience : MonoBehaviour, ICollectible
{
    public int amountXp;
    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseXP(amountXp);
        Destroy(gameObject);
    }
}
