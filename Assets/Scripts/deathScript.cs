using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScript : MonoBehaviour
{
    public void onClickClose()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        MusicManager.Instance.playingMusic = false;
    }
    public void onClickRestart()
    {
        if (GameManager.instance.levelNum == 0)
        {
            SceneManager.LoadScene("RealTutorial", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Testing", LoadSceneMode.Single);
        }
    }
}
