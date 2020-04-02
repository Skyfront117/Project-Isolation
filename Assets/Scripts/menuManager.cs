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
        if (options)
        {
            play = false;
            exit = false;
            credits = false;
            options = false;
            //----> Código a ejecutar! (mostrar el canvas y permitir cambiar las opciones del juego)
        }
        if (credits)
        {
            play = false;
            exit = false;
            credits = false;
            options = false;
            //----> Código a ejecutar! (mostrar el canvas)
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
    public void onClickOptions()
    {
        play = false;
        exit = false;
        credits = false;
        options = true;
    }
    public void onClickCredits()
    {
        play = false;
        exit = false;
        credits = true;
        options = false;
    }
}
