using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour 
{
    MapController mapController;
    public GameObject targetMap;

    void Start()
    {
        mapController = FindObjectOfType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            mapController.currentChunk = targetMap;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
      if(other.CompareTag("Player"))
      {
        if(mapController.currentChunk == targetMap)
        {
            mapController.currentChunk = null;
        }
      }  
    }
}