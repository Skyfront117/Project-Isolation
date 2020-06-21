using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public GameObject alertIndicator;
    private Animator alertAnimator;

    public float score;
    public bool darkness;
    public bool alert;

    public bool playerConnected;

    public bool SEPUEDEPASARELNIVEL3;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            alertAnimator = alertIndicator.GetComponent<Animator>();
        }
        else
        {

        }
        alert = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerConnected = false;
        score = 10000.0f;
        darkness = false;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        SEPUEDEPASARELNIVEL3 = false;
    }

    private void Update()
    {
        if (Time.timeScale < 1.0)
        {
            Cursor.visible = true;
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                Cursor.visible = true;
            }
            else
            {
                if (!playerConnected)
                {
                    Cursor.visible = false;
                }
                else
                {
                    Cursor.visible = true;
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "Testing")
        {
            if (score != 0)
            {
                score -= Time.deltaTime / 4;
            }
            if (score < 0)
            {
                score = 0;
            }
        }
        if (SceneManager.GetActiveScene().name == "RealTutorial")
        {
            darkness = false;
        }
        else
        {
            darkness = true;
        }
    }
}
