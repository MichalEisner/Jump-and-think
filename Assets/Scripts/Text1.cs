using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text1 : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject textBox;
    public GameObject continueText;
    public GameObject[] dialogs; // Pole pro všechny dialogy

    private int dialogIndex = 0;

    void Start()
    {
        // Skryje všechny dialogy na začátku
        foreach (GameObject dialog in dialogs)
        {
            dialog.SetActive(false);  // Ujistíme se, že jsou všechny dialogy skryté
        }
        textBox.SetActive(false);  // Skryje textBox na začátku
        continueText.SetActive(false);  // Skryje continueText na začátku
    }

    void Update()
    {
        // Po stisknutí jakékoliv klávesy zobrazí následující dialog nebo ukončí dialog
        if (Input.anyKeyDown)
        {
            if (dialogIndex >= dialogs.Length)
            {
                // Po posledním dialogu skryj všechny elementy a povol pohyb
                EndDialog();
            }
            else
            {
                ShowNextDialog();
            }
        }
    }

    // Metoda pro spuštění dialogu, volaná z jiného skriptu
    public void StartDialog()
    {
        playerMovement.enabled = false;  // Zakáže pohyb hráče
        textBox.SetActive(true);  // Zobrazí textBox
        ShowNextDialog();
    }

    void ShowNextDialog()
    {
        if (dialogIndex < dialogs.Length)
        {
            // Skryje předchozí dialog
            if (dialogIndex > 0)
            {
                dialogs[dialogIndex - 1].SetActive(false);
            }

            // Zobrazí aktuální dialog
            dialogs[dialogIndex].SetActive(true);
            Debug.Log("Dialog " + dialogIndex); // Debug pro ověření, že dialog je vykreslován

            // Zvětší index pro další dialog
            dialogIndex++;
        }

        // Po posledním dialogu zobrazuje continue text
        if (dialogIndex >= dialogs.Length)
        {
            continueText.SetActive(true);  // Zobrazí text pro pokračování
        }
    }

    // Funkce pro ukončení dialogu a obnovení pohybu hráče
    void EndDialog()
    {
        playerMovement.enabled = true;  // Obnoví pohyb hráče
        textBox.SetActive(false);  // Skryje textBox
        continueText.SetActive(false);  // Skryje continue text

        // Skryje všechny dialogy
        foreach (GameObject dialog in dialogs)
        {
            dialog.SetActive(false);
        }
    }
}
