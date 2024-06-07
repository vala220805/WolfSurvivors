
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Waves
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveMaxEnemiesLimit;
        public float spawnIntervalUntilNextWave;
        public int spawnedTotalEnemiesCount;
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int maxEnemiesLimit;
        public int spawnEnemyCount;
        public GameObject enemyPrefab;
    }

    [Header("Spawner Properties")]
    public List<Waves> waves;
    public int currentWaveIndex;
    public int enemiesStanding;
    public int maxEnemiesAllowed;
    public bool maxReached;
    float spawnTimer;
    public float waveInterval;
    bool IsWaveActive;

    [Header("Spawn Points")]
    public List<Transform> spawnPoints;

    public Transform playerTransform;
   
    private void Start() 
    {
        playerTransform = FindObjectOfType<PlayerStats>().transform;
        CalculateQuota();    
    }
 private void Update() 
    {
        if(currentWaveIndex < waves.Count && waves[currentWaveIndex].spawnedTotalEnemiesCount==0 && !IsWaveActive)
        {
            StartCoroutine(WaveInitator());
        }

        spawnTimer +=  Time.deltaTime;

        if(spawnTimer > waves[currentWaveIndex].spawnIntervalUntilNextWave)
        {
            spawnTimer = 0;
            SpawnEnemies();
        }
    }
    void CalculateQuota()
    {
        int currentQuota = 0;

        foreach (var enemyGroup in waves[currentWaveIndex].enemyGroups)
        {
            currentQuota += enemyGroup.maxEnemiesLimit;
        }

        waves[currentWaveIndex].waveMaxEnemiesLimit = currentQuota;
        Debug.LogWarning(currentQuota);
    }

    void SpawnEnemies()
    {
        if(waves[currentWaveIndex].spawnedTotalEnemiesCount < waves[currentWaveIndex].waveMaxEnemiesLimit && !maxReached)
        {
            foreach (var enemyGroup in waves[currentWaveIndex].enemyGroups)
            {
                if (enemyGroup.spawnEnemyCount < enemyGroup.maxEnemiesLimit)
                {
                    Instantiate(enemyGroup.enemyPrefab, playerTransform.position + spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);

                    enemyGroup.spawnEnemyCount++;
                    waves[currentWaveIndex].spawnedTotalEnemiesCount++;
                    ++enemiesStanding;

                    if (enemiesStanding >= maxEnemiesAllowed)
                    {
                        maxReached = true;
                        return;
                    }
                }
            }
        }

        
    }

    public void EnemyKilled()
    {
        --enemiesStanding;

        if (enemiesStanding < maxEnemiesAllowed)
        {
            maxReached = false;
        }
    }

    IEnumerator WaveInitator()
    {
        IsWaveActive = true;
        yield return new WaitForSeconds(waveInterval);

        if(currentWaveIndex < waves.Count - 1)
        {
            IsWaveActive = false;
            ++currentWaveIndex;
            CalculateQuota();
        }
    }
}
