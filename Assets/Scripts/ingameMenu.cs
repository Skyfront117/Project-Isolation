using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingameMenu : MonoBehaviour
{
    public GameObject thisCanvas;
    public GameObject commandsCanvas;
    public GameObject optionsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void onClickReturn()
    {
        thisCanvas.SetActive(false);
        //----> Descongelar el juego!
        Time.timeScale = 1;
    }
    
    public void onClickCommands()
    {
        thisCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        commandsCanvas.SetActive(true);
    }

    public void onClickOptions()
    {
        thisCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
        commandsCanvas.SetActive(false);
    }
}
