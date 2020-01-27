using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuBehavior : MonoBehaviour
{
    public void exit()
    {
        Application.Quit();
    }

    public void playGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
