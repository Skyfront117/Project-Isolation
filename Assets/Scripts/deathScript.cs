using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScript : MonoBehaviour
{
    public void onClickClose()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void onClickExit()
    {
        Application.Quit();
    }
}
