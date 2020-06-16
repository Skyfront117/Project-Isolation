using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    //private bool play;
    //private bool options;
    //private bool credits;
    //private bool tutorial;
    //private bool exit;
    public Canvas optionsCanvas;
    public Canvas menuCanvas;
    public Canvas creditsCanvas;
    //void Start()
    //{
    //    play = false;
    //    exit = false;
    //    credits = false;
    //    options = false;
    //    tutorial = false;
    //}

    //void Update()
    //{
    //    if (play)
    //    {
    //        MusicManager.Instance.music.Stop();
    //        play = false;
    //        exit = false;
    //        credits = false;
    //        options = false;
    //        tutorial = false;
    //        //----> Normal game
    //        SceneManager.LoadScene("Testing");          
    //    }else
    //    if (exit)
    //    {
    //        play = false;
    //        exit = false;
    //        credits = false;
    //        options = false;
    //        tutorial = false;
    //        Application.Quit();
    //    }else
    //    if (options)
    //    {
    //        play = false;
    //        exit = false;
    //        credits = false;
    //        options = false;
    //        tutorial = false;
    //        menuCanvas.enabled = false;
    //        optionsCanvas.enabled = true;
    //        creditsCanvas.enabled = false;
    //    }else
    //    if (credits)
    //    {
    //        play = false;
    //        exit = false;
    //        credits = false;
    //        options = false;
    //        tutorial = false;
    //        menuCanvas.enabled = false;
    //        optionsCanvas.enabled = false;
    //        creditsCanvas.enabled = true;
    //    }else
    //    if (tutorial)
    //    {
    //        play = false;
    //        exit = false;
    //        credits = false;
    //        options = false;
    //        tutorial = false;
    //        //----> Tutorial
    //        SceneManager.LoadScene("RealTutorial");
    //    }
    //}

    public void onClickPlay()
    {
        MusicManager.Instance.music.Stop();
        //play = true;
        //exit = false;
        //credits = false;
        //options = false;
        //----> Normal game
        SceneManager.LoadScene("Testing");
    }

    public void onClickClose()
    {
        //play = false;
        //exit = true;
        //credits = false;
        //options = false;
        Application.Quit();
    }
    public void onClickOptions()
    {
        //play = false;
        //exit = false;
        //credits = false;
        //options = true;
        menuCanvas.enabled = false;
        optionsCanvas.enabled = true;
        creditsCanvas.enabled = false;
    }
    public void onClickCredits()
    {
        //play = false;
        //exit = false;
        //credits = true;
        //options = false;
        menuCanvas.enabled = false;
        optionsCanvas.enabled = false;
        creditsCanvas.enabled = true;
    }
    public void onClickTutorial()
    {
        MusicManager.Instance.music.Stop();
        //----> Tutorial
        SceneManager.LoadScene("RealTutorial");
    }
}
