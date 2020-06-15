using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public AudioSource audio;
    public AudioClip shot;
    public AudioClip steps;
    public AudioClip bloodsplatter;
    public AudioClip heartbeat;
    public AudioClip athenadamage;
    public AudioClip alerton;
    public AudioClip alertoff;
    public AudioClip invon;
    public AudioClip invoff;
    public AudioClip noammo;

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
    public void PlayDamage()
    {
        if (Time.timeScale == 1)
        {
            audio.PlayOneShot(athenadamage);
        }

    }
    public void PlayAlertOn()
    {
        if (Time.timeScale == 1)
        {
            audio.PlayOneShot(alerton);
        }

    }
    public void PlayAlertOff()
    {
        if (Time.timeScale == 1)
        {
            audio.PlayOneShot(alertoff);
        }

    }
    public void PlayInvOff()
    {
        if (Time.timeScale == 1)
        {
            audio.PlayOneShot(invon);
        }

    }
    public void PlayInvOn()
    {
        if (Time.timeScale == 1)
        {
            audio.PlayOneShot(invoff);
        }

    }
    public void PlayNoAmmo()
    {
        if (Time.timeScale == 1)
        {
            audio.PlayOneShot(noammo);
        }

    }
}
