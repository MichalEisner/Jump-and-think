using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSystem : MonoBehaviour
{
    public Text1 dialogSystem;

    public int end = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (end == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dialogSystem.EndDialog();
                Debug.Log("End System - EndDialog()");
            }
        }
    }
}
