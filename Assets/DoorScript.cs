using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject console;

    public void ActivateConsole()
    {
        console.SetActive(true);
    }

    public void DisActivateConsole()
    {
        console.SetActive(false);
    }
}