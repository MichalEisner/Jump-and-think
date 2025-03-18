using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
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
        if (openMenu)
        {
            playerMovement.enabled = false;
            Cursor.visible = true;
            animator.enabled = false;
        }
    }
    public void OpenDeadMenu()
    {
        openMenu = true;
        canvas.enabled = openMenu;
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
