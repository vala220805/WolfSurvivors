using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName ="ScriptableObjects/Weapon")]
public class WeaponSO : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
   public GameObject Prefab { get => prefab; private set => prefab = value; }
   [SerializeField]
   float damage;
   public float Damage { get => damage; set => damage = value; }
   [SerializeField]
   float attackInterval;
   public float AttackInterval { get => attackInterval; private set => attackInterval = value; }
}
