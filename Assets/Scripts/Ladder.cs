using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public bool isOnLadder = false;
    float defaultGravity = 0;
    float defaultGravityInJump = 0;

    void Start()
    {
        defaultGravity = playerMovement.gravity;
        defaultGravityInJump = playerMovement.gravityInJump;
    }    
    void Update()
    {
        if (isOnLadder && Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.rb.velocity = new Vector2(playerMovement.rb.velocity.x, playerMovement.jumpingPower);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOnLadder = true;
            playerMovement.gravity = 0;
            playerMovement.gravityInJump = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOnLadder = false;
            playerMovement.gravity = defaultGravity;
            playerMovement.gravityInJump = defaultGravityInJump;
        }
    }
}
