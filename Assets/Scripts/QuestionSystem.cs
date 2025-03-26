using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSystem : MonoBehaviour
{
    public GameObject rightChoice;
    public GameObject wrongChoice1, wrongChoice2, wrongChoice3;
    public GameObject background;
    public GameObject continueText;
    public Text1 dialogSystem;
    public EndSystem endSystem;

    // Start is called before the first frame update
    void Start()
    {
        background.transform.position = new Vector3(
            background.transform.position.x,  // Zachová původní X
            background.transform.position.y + 0.7f,  // Zvýší Y o 0.7
            background.transform.position.z - 10  // Zachová původní Z
        );
        rightChoice.SetActive(true);
        wrongChoice1.SetActive(true);
        wrongChoice2.SetActive(true);
        wrongChoice3.SetActive(true);
        continueText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RightAnswer()
    {
        background.transform.position = new Vector3(
            background.transform.position.x,  // Zachová původní X
            background.transform.position.y - 0.7f,  // Zvýší Y o 0.7
            background.transform.position.z + 10  // Zachová původní Z
        );
        rightChoice.SetActive(false);
        wrongChoice1.SetActive(false);
        wrongChoice2.SetActive(false);
        wrongChoice3.SetActive(false);
        continueText.SetActive(true);

        dialogSystem.ShowNextDialog();
        endSystem.end = 1;
    }

    public void WrongAnswer()
    {
        background.transform.position = new Vector3(
            background.transform.position.x,  // Zachová původní X
            background.transform.position.y - 0.7f,  // Zvýší Y o 0.7
            background.transform.position.z + 10  // Zachová původní Z
        );
        rightChoice.SetActive(false);
        wrongChoice1.SetActive(false);
        wrongChoice2.SetActive(false);
        wrongChoice3.SetActive(false);
        continueText.SetActive(true);

        dialogSystem.ShowNextDialog();
        dialogSystem.ShowNextDialog();
    }
}
