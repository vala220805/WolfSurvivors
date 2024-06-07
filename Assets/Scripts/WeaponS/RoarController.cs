using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoarController : WeaponController
{
       protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject roarPrefab = Instantiate(weaponSO.Prefab, transform);

        roarPrefab.transform.position = transform.position;
    }

}
