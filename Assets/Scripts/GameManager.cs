﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public GameObject alertIndicator;
    private Animator alertAnimator;

    public int levelNum;
    public bool darkness;
    public bool alert;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            alertAnimator = alertIndicator.GetComponent<Animator>();
        }
        else
        {
            Debug.Log("Too many " + this + " in scene.");
        }
        alert = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        darkness = true;
        levelNum = 0;
        BinaryReader reader;
        if (File.Exists("save.sav"))
        {
            reader = new BinaryReader(File.Open("save.sav", FileMode.Open));
            levelNum = reader.ReadInt32();
            reader.Close();
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            MusicManager.Instance.playingMusic = false;
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void saveProgress()
    {
        levelNum++;
        BinaryWriter writer = new BinaryWriter(File.Open("save.sav", FileMode.Create));
        writer.Write(levelNum);
        writer.Close();
    }
}
