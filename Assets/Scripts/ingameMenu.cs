using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingameMenu : MonoBehaviour
{
    public Canvas thisCanvas;
    public Canvas commandsCanvas;
    public Canvas optionsCanvas;
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
        thisCanvas.enabled = false;
        //----> Descongelar el juego!
        Time.timeScale = 1;
    }
    
    public void onClickCommands()
    {
        thisCanvas.enabled = false;
        optionsCanvas.enabled = false;
        commandsCanvas.enabled = true;
    }

    public void onClickOptions()
    {
        thisCanvas.enabled = false;
        optionsCanvas.enabled = true;
        commandsCanvas.enabled = false;
    }
}
