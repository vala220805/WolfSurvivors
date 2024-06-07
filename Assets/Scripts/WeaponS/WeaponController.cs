using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponSO weaponSO;
    float attackInterval;

    private PlayerMovement playerMovement;

    protected virtual void Start() 
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        attackInterval = weaponSO.AttackInterval;
    }

    protected virtual void Update() 
    {
        attackInterval -= Time.deltaTime;

        if (attackInterval <= 0)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        attackInterval = weaponSO.AttackInterval;
    }


}
