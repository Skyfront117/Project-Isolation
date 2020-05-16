using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    private AudioSource music;
    public AudioClip mainTheme;
    public AudioClip combatMusic;
    public bool playingMusic = false;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            music.clip = mainTheme;
        }
        else
        {
            music.clip = combatMusic;
        }
        if (!playingMusic)
        {
            music.Play();
            playingMusic = true;
        }
    }
}
