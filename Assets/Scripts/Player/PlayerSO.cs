using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/Player")]
public class PlayerSO : ScriptableObject
{   
    [SerializeField]
    private float maxHealth;
    public float MaxHealth {get => maxHealth; set => maxHealth = value; }
    [SerializeField]
    private float experience;
    public float Experience {get => experience; set => experience = value; }
    [SerializeField]
    private int level;
    public int Level {get => level; set => level = value; }
    [SerializeField]
    private int defeatedEnemies;
    public int DefeatedEnemies {get => defeatedEnemies; set => defeatedEnemies = value; }
    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed {get => moveSpeed; set => moveSpeed = value; }    

}
