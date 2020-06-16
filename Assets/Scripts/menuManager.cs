using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    private bool play;
    private bool options;
    private bool credits;
    private bool exit;
    public Canvas optionsCanvas;
    public Canvas menuCanvas;
    public Canvas creditsCanvas;
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
            MusicManager.Instance.music.Stop();
            play = false;
            exit = false;
            credits = false;
            options = false;
            if (GameManager.instance.levelNum == 0)
            {
                //----> Tutorial
                SceneManager.LoadScene("Testing");
            } else
            {
                //----> Normal game
                SceneManager.LoadScene("Testing");
            }            
        }else
        if (exit)
        {
            play = false;
            exit = false;
            credits = false;
            options = false;
            Application.Quit();
        }else
        if (options)
        {
            play = false;
            exit = false;
            credits = false;
            options = false;
            menuCanvas.enabled = false;
            optionsCanvas.enabled = true;
            creditsCanvas.enabled = false;
        }else
        if (credits)
        {
            play = false;
            exit = false;
            credits = false;
            options = false;
            menuCanvas.enabled = false;
            optionsCanvas.enabled = false;
            creditsCanvas.enabled = true;
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
