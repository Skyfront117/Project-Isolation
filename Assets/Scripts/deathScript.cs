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
        SceneManager.LoadScene("Testing", LoadSceneMode.Single);
    }
}
