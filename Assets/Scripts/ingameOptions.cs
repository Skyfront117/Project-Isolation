using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingameOptions : MonoBehaviour
{
    public Canvas menuCanvas;
    public Canvas optionsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onClickBack()
    {
        optionsCanvas.enabled = false;
        menuCanvas.enabled = true;
    }


}
