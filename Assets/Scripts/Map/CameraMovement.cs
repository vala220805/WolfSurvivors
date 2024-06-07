using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset = new Vector3(0, 0, -10);
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
