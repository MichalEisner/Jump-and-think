using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCMenu : MonoBehaviour
{
    public Canvas canvas;
    public PlayerMovement playerMovement;
    public Animator animator;
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
            animator.enabled = false; // Zakazuje animace hráče
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && openMenu)
        {
            openMenu = false;
            canvas.enabled = false; // Přepíná aktuální stav kódu canvasu
            playerMovement.enabled = true; // Povoluje pohyb hráče
            animator.enabled = true; // Povoluje animace hráče
            Cursor.visible = false;
        }
    }
    public void Resume()
    {
        openMenu = false;
        canvas.enabled = false; // Přepíná aktuální stav kódu canvasu
        playerMovement.enabled = true; // Povoluje pohyb hráče
        animator.enabled = true; // Povoluje animace hráče
    }
    public void Quit()
    {
        Application.Quit(); // Ukončí hru
    }
    public void Reset()
    {
        SceneManager.LoadScene("Hra");
    }
}
