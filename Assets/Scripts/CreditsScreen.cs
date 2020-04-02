using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScreen : MonoBehaviour
{
    public Canvas menuCanvas;
    public Canvas optionsCanvas;
    public Canvas creditsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickQuit()
    {
        optionsCanvas.enabled = false;
        creditsCanvas.enabled = false;
        menuCanvas.enabled = true;
    }
}
