using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator playerAnimator;
    private PlayerMovement playerMovement;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.direction.x != 0)
        {
            playerAnimator.SetBool("MoveSide",true);
            SpriteDirectionChecker();
        }
        else
        {
            playerAnimator.SetBool("MoveSide", false);
        }
        if(playerMovement.direction.y > 0)
        {
            playerAnimator.SetBool("MoveUp", true);
        }
        else
        {
            playerAnimator.SetBool("MoveUp", false);
        }
        if (playerMovement.direction.y < 0)
        {
            playerAnimator.SetBool("MoveDown", true);
        }
        else
        {
            playerAnimator.SetBool("MoveDown", false);   
        }
    }

    void SpriteDirectionChecker()
    {
        if(playerMovement.direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
