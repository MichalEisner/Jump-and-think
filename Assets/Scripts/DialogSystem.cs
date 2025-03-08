using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text1 : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public KeyFunction keyFunction;
    public GameObject textBox;
    public GameObject continueText;
    public GameObject[] dialogs;

    private int dialogIndex = 0;

    void Start()
    {
        // Skryje všechny dialogy, textBox a continueText na začátku
        foreach (GameObject dialog in dialogs)
        {
            dialog.SetActive(false);
        }
        textBox.SetActive(false);
        continueText.SetActive(false);
    }

    void Update()
    {
        // Po stisknutí jakékoliv klávesy zobrazí další dialog nebo ukončí dialog
        if (Input.anyKeyDown)
        {
            ShowNextDialog();
        }
    }

    // Metoda pro spuštění dialogu, volaná z jiného skriptu
    public void StartDialog()
    {
        dialogIndex = 0;  // Reset indexu, aby se dialog vždy spustil od začátku
        playerMovement.enabled = false;  
        textBox.SetActive(true);
        continueText.SetActive(true);
        ShowNextDialog();
    }

    void ShowNextDialog()
    {
        // Pokud je dialogIndex mimo rozsah, ukončí dialog
        if (dialogIndex >= dialogs.Length)
        {
            EndDialog();
            return;
        }

        // Skryje předchozí dialog (pokud nějaký byl)
        if (dialogIndex > 0)
        {
            dialogs[dialogIndex - 1].SetActive(false);
        }

        // Zobrazí aktuální dialog
        dialogs[dialogIndex].SetActive(true);
        Debug.Log("Zobrazen dialog: " + dialogIndex);

        dialogIndex++;  // Zvýší index až po zobrazení dialogu

        // Pokud jsme na konci, zobrazí continueText
        if (dialogIndex >= dialogs.Length)
        {
            continueText.SetActive(true);
        }
    }

    // Funkce pro ukončení dialogu a obnovení pohybu hráče
    void EndDialog()
    {
        playerMovement.enabled = true;
        textBox.SetActive(false);
        continueText.SetActive(false);

        // Skryje všechny dialogy
        foreach (GameObject dialog in dialogs)
        {
            dialog.SetActive(false);
        }
    }
}
