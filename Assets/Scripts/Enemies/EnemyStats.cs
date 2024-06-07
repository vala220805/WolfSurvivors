using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemySO enemySO;

    [HideInInspector]
    public float currentDamage;
    [HideInInspector]
    public float currentSpeed;
    [HideInInspector]
    public float currentHealth;

    public float despawnDistance = 20f;
    Transform player;

    private Animator animator;
    EnemySpawner enemySpawner;


    private void Awake() {
        currentDamage = enemySO.Damage;
        currentSpeed = enemySO.MoveSpeed;
        currentHealth = enemySO.MaxHealth;
        animator = GetComponent<Animator>();
    }
    
    private void Start() 
    {
        player = FindObjectOfType<PlayerStats>().transform;  
        enemySpawner = FindObjectOfType<EnemySpawner>(); 
    }

    private void Update() 
    {
        if (Vector2.Distance(transform.position, player.position) >= despawnDistance)
        {
            Despawn();
        }
    }

    public void GetHit(float weaponPower)
    {
        currentHealth -= weaponPower;
        
        animator.SetTrigger("Hit");

        if (currentHealth <= 0)
        {
            StartCoroutine(Die("Life"));
        }
    }

    IEnumerator Die(string animatorName)
    {
        animator.SetFloat(animatorName, currentHealth);

        while(animator.GetCurrentAnimatorStateInfo(0).IsName(animatorName) &&
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2.5f);

        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        playerStats.IncreaseVictories();

        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().GetHit(currentDamage);
        }
    }

    private void OnDestroy() 
    {
        enemySpawner.EnemyKilled();
    }

    void Despawn()
    {
        transform.position = player.position + enemySpawner.spawnPoints[UnityEngine.Random.Range(0, enemySpawner.spawnPoints.Count)].position;
    }
}
