using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    public AudioSource music;
    public AudioClip mainTheme;
    public AudioClip combatMusic;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            music.clip = mainTheme;
            if (!music.isPlaying)
            {
                music.Play();
            }
        }
        else if (SceneManager.GetActiveScene().name != "RealTutorial" && GameManager.instance.alert)
        {
            music.clip = combatMusic;
            if (!music.isPlaying)
            {
                music.Play();
            }
        }


    }
}
