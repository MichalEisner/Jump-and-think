using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCMenu : MonoBehaviour
{
    public Canvas canvas;
    public PlayerMovement playerMovement;
    bool openMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = openMenu;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !openMenu)
        {
            openMenu = true;
            canvas.enabled = true; // Přepíná aktuální stav kódu canvasu
            playerMovement.enabled = false; // Zakazuje pohyb hráče
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && openMenu)
        {
            openMenu = false;
            canvas.enabled = false; // Přepíná aktuální stav kódu canvasu
            playerMovement.enabled = true; // Povoluje pohyb hráče
        }
    }
    public void Resume()
    {
        openMenu = false;
        canvas.enabled = false; // Přepíná aktuální stav kódu canvasu
        playerMovement.enabled = true; // Povoluje pohyb hráče
    }
    public void Quit()
    {
        Application.Quit(); // Ukončí hru
    }
}
