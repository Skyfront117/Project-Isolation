using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public bool play;
    private bool options;
    private bool credits;
    private bool exit;
    void Start()
    {
        play = false;
        exit = false;
        credits = false;
        options = false;
    }

    void Update()
    {
        if (play)
        {
            play = false;
            exit = false;
            credits = false;
            options = false;
            SceneManager.LoadScene("Tutorial");
        }
        if (exit)
        {
            play = false;
            exit = false;
            credits = false;
            options = false;
            Application.Quit();
        }
    }

    public void onClickPlay()
    {
        play = true;
        exit = false;
        credits = false;
        options = false;
    }

    public void onClickClose()
    {
        play = false;
        exit = true;
        credits = false;
        options = false;
    }
}
