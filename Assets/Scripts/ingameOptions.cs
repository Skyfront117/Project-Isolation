using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingameOptions : MonoBehaviour
{
    public Canvas menuCanvas;
    public Canvas optionsCanvas;
    private AudioSource effectsAudio;
    private float newVolume;
    public Slider effectsSlider;
    // Start is called before the first frame update
    void Start()
    {
        effectsAudio = GameObject.Find("ManagersContainer").GetComponent<AudioSource>();
        newVolume = 0;
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

    public void changeEffectsVolume()
    {
        newVolume = effectsSlider.value;
        effectsAudio.volume = newVolume;
    }
}
