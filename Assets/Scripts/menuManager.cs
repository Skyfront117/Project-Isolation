﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public Button play;
    public Button exit;
    void Start()
    {

    }

    void Update()
    {

    }

    public void onClickPlay()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void onClickClose()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
