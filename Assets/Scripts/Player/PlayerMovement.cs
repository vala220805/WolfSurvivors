using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rigidbody2D;
    [HideInInspector]
    public Vector2 direction;

    private PlayerStats player;

    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }

    private void FixedUpdate() {
        Move();
    }

    private void InputHandler()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        float yDirection = Input.GetAxisRaw("Vertical");

        direction = new Vector2(xDirection, yDirection).normalized;
    }

    private void Move()
    {
        transform.Translate(direction * player.currentSpeed * Time.deltaTime);
        //rigidbody2D.velocity = new Vector2(direction.x * player.currentSpeed, direction.y * player.currentSpeed);
    }

    

}
