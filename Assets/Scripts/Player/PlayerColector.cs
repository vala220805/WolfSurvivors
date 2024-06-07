using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColector : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other) 
   {
        if (other.gameObject.TryGetComponent(out ICollectible collectible))
        {
            collectible.Collect();
        }
   }
}
