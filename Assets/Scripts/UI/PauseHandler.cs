using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseGame();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            Resume();
        }
    }
    
   public void PauseGame()
   {
     Time.timeScale = 0f;
   }

   public void Resume()
   {
      Time.timeScale = 1.0f;
   }
}
