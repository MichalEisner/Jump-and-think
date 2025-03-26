using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text1 : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject textBox;
    public GameObject continueText;
    public GameObject KeyFunction;
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
        if (Input.GetKeyDown(KeyCode.Space))
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

    // Metoda pro spuštění konkrétního dialogu podle názvu
    public void ShowSingleDialog(string dialogName)
    {
        dialogIndex = 0;  // Reset indexu pro konkrétní dialog
        playerMovement.enabled = false;
        textBox.SetActive(true);
        continueText.SetActive(true);

        // Skryje všechny dialogy a zobrazí pouze ten, který odpovídá názvu
        foreach (GameObject dialog in dialogs)
        {
            dialog.SetActive(false);
            if (dialog.name == dialogName)
            {
                dialog.SetActive(true);
                Debug.Log("Zobrazen dialog: " + dialogName);
                break;
            }
        }
        EndDialog();
    }

    public void ShowNextDialog()
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
    public void EndDialog()
    {
        playerMovement.enabled = true;
        textBox.SetActive(false);
        continueText.SetActive(false);

        // Skryje všechny dialogy
        foreach (GameObject dialog in dialogs)
        {
            dialog.SetActive(false);
        }
        Destroy(KeyFunction);
    }
}
