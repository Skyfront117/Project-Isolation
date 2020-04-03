using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionsMenu : MonoBehaviour
{
    public Canvas optionsCanvas;
    public Canvas menuCanvas;
    public AudioSource soundAudio;
    public AudioSource musicAudio;
    public Slider effectsSlider;
    public Slider musicSlider;
    private float newEffectsVolume;
    private float newMusicVolume;
    // Start is called before the first frame update
    void Start()
    {
        newEffectsVolume = 0;
        newMusicVolume = 0;
    }

    public void changeEffectsVolume()
    {
        newEffectsVolume = effectsSlider.value;
        soundAudio.volume = newEffectsVolume;
    }

    public void changeMusicVolume()
    {
        newMusicVolume = musicSlider.value;
        musicAudio.volume = newMusicVolume;
    }
    public void onClickClose()
    {
        optionsCanvas.enabled = false;
        menuCanvas.enabled = true;
    }
}
