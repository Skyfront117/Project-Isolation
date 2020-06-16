using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScript : MonoBehaviour
{
    public void onClickClose()
    {
        MusicManager.Instance.music.Stop();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void onClickRestart()
    {
        MusicManager.Instance.music.Stop();
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
