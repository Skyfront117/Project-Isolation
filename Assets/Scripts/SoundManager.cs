using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public AudioSource audioShot;
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
        audioShot = GetComponent<AudioSource>();
    }

    public void PlayShot()
    {
        audioShot.PlayOneShot(audioShot.clip);
    }
}
