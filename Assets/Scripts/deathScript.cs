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
        if (SceneManager.GetActiveScene().name == "RealTutorial")
        {
            SceneManager.LoadScene("RealTutorial", LoadSceneMode.Single);
        }
        else if(SceneManager.GetActiveScene().name == "Testing")
        {
            SceneManager.LoadScene("Testing", LoadSceneMode.Single);
        }
    }
}
