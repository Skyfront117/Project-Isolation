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
    private bool playStart;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playStart = false;
        music = GetComponent<AudioSource>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (!playStart)
            {
                playStart = true;
                Debug.Log("Menumusiquita");
                music.clip = mainTheme;
                if (!music.isPlaying)
                {
                    music.Play();
                }
            }            
        }
        else if (SceneManager.GetActiveScene().name != "RealTutorial" && GameManager.instance.alert)
        {
            Debug.Log("XD");
            music.clip = combatMusic;
            if (!music.isPlaying)
            {
                music.Play();
            }
        }
        else
        {
            playStart = false;
            music.Stop();
        }


    }
}
