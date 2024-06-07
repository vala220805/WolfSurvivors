using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Transform playerTransform;
    private Vector2 playerPosition;
    private Vector2 enemyPosition;

    private EnemyStats enemy;
   

    private void Start() 
    {
        enemy = FindObjectOfType<EnemyStats>();
        playerTransform = FindObjectOfType<PlayerStats>().transform;
    }
    
    void Update()
    {
        float enemySpeed = enemy.currentSpeed * Time.deltaTime;
        playerPosition = Vector2.MoveTowards(transform.position, playerTransform.transform.position, enemySpeed );

        transform.position = playerPosition;
    }

    


}
