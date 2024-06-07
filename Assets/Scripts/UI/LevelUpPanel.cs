using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpPanel : MonoBehaviour
{
    public PauseHandler pauseHandler;

    public GameObject levelUpPanel;

    [SerializeField]
    private void Start() 
    {
        pauseHandler = FindObjectOfType<PauseHandler>();
    }

    public void LevelUp()
    {
        levelUpPanel.SetActive(true);
        pauseHandler.PauseGame();
    }
}
