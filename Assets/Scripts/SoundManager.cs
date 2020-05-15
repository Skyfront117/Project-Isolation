using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private AudioSource audio;
    public AudioClip shot;
    public AudioClip steps;
    public AudioClip bloodsplatter;
    public AudioClip heartbeat;
    private void Awake()
    {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayShot()
    {
        if(Time.timeScale == 1)
        {
            audio.PlayOneShot(shot);
        }
        
    }

    public void PlaySteps()
    {
        if (Time.timeScale == 1)
        {
            audio.PlayOneShot(steps);
        }
    }

    public void PlayBlood()
    {
        if (Time.timeScale == 1)
        {
            audio.PlayOneShot(bloodsplatter);
        }
    }
    public void PlayBeat()
    {
        if (Time.timeScale == 1)
        {
            audio.PlayOneShot(heartbeat);
        }

    }
}
