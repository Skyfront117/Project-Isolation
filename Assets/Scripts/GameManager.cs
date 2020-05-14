﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public int levelNum;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log("Too many " + this + " in scene.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
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
            SceneManager.LoadScene("Level1");
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
