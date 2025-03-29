using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite respawnPointActive;
    public GameObject respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            respawnPoint.transform.position = this.transform.position;
            spriteRenderer.sprite = respawnPointActive;
            Debug.Log("Respawn point moved");   
        }
    }
}
