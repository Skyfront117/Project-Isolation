using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3Activator : MonoBehaviour
{
    public GameObject console;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject clearButton;
    public GameObject consoleText;
    public GameObject clearScreenButton;
    private PlayerController playerScript;

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactScript.instance.canInteract = true;
            if (InputManager.Instance.consoleConect && playerScript.canMove)
            {
                ActivateConsole();
            }
        }
        else
        {
            interactScript.instance.canInteract = false;
        }
    }

    public void ActivateConsole()
    {
        console.SetActive(true);
        console.GetComponent<Level3ConsoleManager>().playerConnected = true;
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);
        clearButton.SetActive(true);
        consoleText.SetActive(true);
        clearScreenButton.SetActive(true);

        playerScript.canMove = false;
        playerScript.isHacking = true;
    }

    public void DisActivateConsole()
    {
        console.GetComponent<Level3ConsoleManager>().playerConnected = false;
        console.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        clearButton.SetActive(false);
        consoleText.SetActive(false);
        clearScreenButton.SetActive(false);

        playerScript.canMove = true;
        playerScript.isHacking = false;
    }
}
