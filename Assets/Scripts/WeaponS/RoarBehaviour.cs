using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoarBehaviour : MonoBehaviour
{
    public WeaponSO roarSO;
    private float secondsToDestroy = .6f;
    private float damage;

    private void Awake() 
    {
        damage = roarSO.Damage;    
    }

    private void Start() 
    {
        Destroy(gameObject, secondsToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.gameObject.GetComponent<EnemyStats>();

            enemy.GetHit(damage);
        }
        
    }


}
