using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public GameObject RespawnPoint;
    public GameObject Player;
    public Heart heart1, heart2, heart3;
    public DeadMenu deadMenu;
    public int hearts = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Systém pro srdíčka
        if (hearts == 3)
        {
            heart1.HeartUp();
            heart2.HeartUp();
            heart3.HeartUp();
        }
        else if (hearts == 2)
        {
            heart1.HeartUp();
            heart2.HeartUp();
            heart3.HeartDown();
        }
        else if (hearts == 1)
        {
            heart1.HeartUp();
            heart2.HeartDown();
            heart3.HeartDown();
        }
        else if (hearts == 0)
        {
            heart1.HeartDown();
            heart2.HeartDown();
            heart3.HeartDown();
            deadMenu.OpenDeadMenu();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead")
        {
            Respawn();
        }
    }
    void Respawn()
    {
        Debug.Log("Respawn");
        if (RespawnPoint != null)
        {
            Player.transform.position = RespawnPoint.transform.position;
            hearts--;
        }
    }
}
