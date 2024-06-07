using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerSO playerSO;

    [HideInInspector]
    public float currentPlayerHealth;
    [HideInInspector]
    public float currentExperience;
    [HideInInspector]
    public int victories;
    [HideInInspector]
    public float currentSpeed;
    public int level;
    public int experienceCap;
    private float healthLimit;

    public WeaponSO selectedWeapon;
    
    [System.Serializable]
    public class ExperiencePerLevels
    {
        public int startLevel;
        public int endLevel;
        public int experienceAmount;
    }

    public List<ExperiencePerLevels> levelsCap = new List<ExperiencePerLevels>();
    public PlayerPanelStats panelStats;
    private Animator animator;
    public GameObject gameOverPanel;
    public LevelUpPanel levelUpPanel;

    private void Awake()
    {
        currentPlayerHealth = playerSO.MaxHealth;
        currentExperience = playerSO.Experience;
        currentSpeed = playerSO.MoveSpeed;
        victories = playerSO.DefeatedEnemies;
        level = playerSO.Level;
        healthLimit = playerSO.MaxHealth;
    }

    private void Start() 
    {
        experienceCap = levelsCap[0].experienceAmount;
        animator = FindObjectOfType<PlayerStats>().GetComponent<Animator>();
        panelStats = FindObjectOfType<PlayerPanelStats>();
        levelUpPanel = FindObjectOfType<LevelUpPanel>();
    }

    public void IncreaseHealth(float healthAmount)
    {
        currentPlayerHealth += healthAmount;
        panelStats.UpdateData();

        if(currentPlayerHealth > healthLimit)
        {
            currentPlayerHealth = healthLimit;
        }
        
    }

    public float xpToPercent()
    {
        float percent = (currentExperience * 100) / experienceCap;
        return percent / 100;
    }

    public void IncreaseXP(float amount)
    {
        currentExperience += amount;
        panelStats.UpdateData();

        CheckCurrentLevel();
    }

    public void IncreaseVictories()
    {
        ++victories;
        panelStats.UpdateData();
    }

    public void IncreaseAttackPwr(float power)
    {
        selectedWeapon.Damage += power;
    }

    public void IncreaseSpeed(float speed)
    {
        currentSpeed += speed;
    }

    public void DoubleXP()
    {
        IncreaseXP(currentExperience);
    }

    private void CheckCurrentLevel()
    {
        if(currentExperience > experienceCap)
        {
            level++;
            currentExperience -= experienceCap;
            panelStats.UpdateData();

            foreach(var range in levelsCap)
            {
                if(level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCap = range.experienceAmount;
                    break;
                }
            }

            levelUpPanel.LevelUp();
        }
    }

    public void GetHit(float enemyPower)
    {
        currentPlayerHealth -= enemyPower;
        panelStats.UpdateData();

        if (currentPlayerHealth <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        StartCoroutine(WaitAnimation());
        gameOverPanel.SetActive(true);
        PauseHandler pauseHandler = FindObjectOfType<PauseHandler>();
        pauseHandler.PauseGame();
    }

    IEnumerator WaitAnimation()
    {
        animator.SetFloat("Life", currentPlayerHealth);

        while(animator.GetCurrentAnimatorStateInfo(0).IsName("Life") &&
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2.5f);

        gameOverPanel.SetActive(true);
        PauseHandler pauseHandler = FindObjectOfType<PauseHandler>();
        pauseHandler.PauseGame();
    }

    public void StopRoutines()
    {
        StopCoroutine(WaitAnimation());
    }
    
}
