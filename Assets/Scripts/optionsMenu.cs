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
    public float newMusicVolume;
    private bool volumeAudioUP;
    private bool volumeMusicUP;
    // Start is called before the first frame update
    void Start()
    {
        //soundAudio = GetComponent<AudioSource>();
        //musicAudio = GetComponent<AudioSource>();
        //effectsSlider = GetComponent<Slider>();
        //musicSlider = GetComponent<Slider>();
        newEffectsVolume = 0;
        newMusicVolume = 0;
        volumeAudioUP = false;
        volumeMusicUP = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (volumeAudioUP)
        {
            soundAudio.volume = newEffectsVolume;
        }
        if (volumeMusicUP)
        {
            musicAudio.volume = newMusicVolume;
        }
    }

    public void changeEffectsVolume()
    {
        newEffectsVolume = effectsSlider.value;
        volumeAudioUP = true;
        volumeMusicUP = false;
    }

    public void changeMusicVolume()
    {
        newMusicVolume = musicSlider.value;
        volumeAudioUP = false;
        volumeMusicUP = true;
    }
    public void onClickClose()
    {
        optionsCanvas.enabled = false;
        menuCanvas.enabled = true;
    }
}
