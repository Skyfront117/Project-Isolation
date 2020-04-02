using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScript : MonoBehaviour
{
    private bool playAgain;
    private bool exit;
    void Start()
    {
        playAgain = false;
    }

    void Update()
    {
        if (playAgain)
        {
            playAgain = false;
            exit = false;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        if (exit)
        {
            playAgain = false;
            exit = false;
            Application.Quit();
        }
    }

    public void onClickClose()
    {
        playAgain = true;
        exit = false;
    }
    public void onClickExit()
    {
        playAgain = false;
        exit = true;
    }
}
