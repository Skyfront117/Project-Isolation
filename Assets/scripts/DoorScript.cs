using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject console;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject clearButton;
    public GameObject consoleText;

    public void ActivateConsole()
    {
        console.SetActive(true);
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);
        clearButton.SetActive(true);
        consoleText.SetActive(true);
    }

    public void DisActivateConsole()
    {
        console.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        clearButton.SetActive(false);
        consoleText.SetActive(false);
    }
}