using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class PlayerPanelStats : MonoBehaviour
{
    [SerializeField]
    Image healthBar;
    [SerializeField]
    Image xpBar;
    [SerializeField]
    TextMeshProUGUI levelTxt;
    [SerializeField]
    TextMeshProUGUI deathsTxt;
    
    PlayerStats playerStats;

    private void Start() 
    {
        playerStats = FindObjectOfType<PlayerStats>();
        UpdateData();
    }

    public void UpdateData()
    {
        healthBar.fillAmount = (float)(playerStats.currentPlayerHealth / playerStats.playerSO.MaxHealth);
        xpBar.fillAmount = (float)(playerStats.xpToPercent());
        levelTxt.text = playerStats.level.ToString();
        deathsTxt.text = playerStats.victories.ToString();
    }
}
