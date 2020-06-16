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
        soundAudio = GameObject.Find("ManagersContainer").GetComponent<AudioSource>();
        musicAudio = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        newEffectsVolume = 1;
        newMusicVolume = 0.2f;
        soundAudio.volume = newEffectsVolume;
        musicAudio.volume = newMusicVolume;
    }

    public void changeEffectsVolume()
    {
        newEffectsVolume = effectsSlider.value;
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
