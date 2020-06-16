using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public Canvas optionsCanvas;
    public Canvas menuCanvas;
    public Canvas creditsCanvas;

    public void onClickPlay()
    {
        MusicManager.Instance.music.Stop();
        //----> Normal game
        SceneManager.LoadScene("Testing");
    }

    public void onClickClose()
    {
        Application.Quit();
    }
    public void onClickOptions()
    {
        menuCanvas.enabled = false;
        optionsCanvas.enabled = true;
        creditsCanvas.enabled = false;
    }
    public void onClickCredits()
    {
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
