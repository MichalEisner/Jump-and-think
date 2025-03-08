using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFunction : MonoBehaviour
{
    public GameObject key;
    public Text1 text1Script;  // Odkaz na Text1 skript
    bool IsTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        key.SetActive(false);  // Skryje klíč při spuštění
    }

    // Update is called once per frame
    void Update()
    {
        // Pokud je hráč v triggeru a stiskne E, spustí se dialogy
        if (IsTriggered && Input.GetKey(KeyCode.E))
        {
            Destroy(key);  // Zničí klíč
            if (text1Script != null)
            {
                text1Script.StartDialog();  // Zavolá StartDialog() z Text1 skriptu
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            key.SetActive(true);  // Zobrazí klíč, když hráč vstoupí do triggeru
            IsTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            key.SetActive(false);  // Skryje klíč, když hráč opustí trigger
            IsTriggered = false;
        }
    }
}
