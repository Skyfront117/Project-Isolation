﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public bool shooting;
    public bool interact;
    public bool moveRight;
    public bool moveLeft;
    public bool moveUp;
    public bool moveDown;
    public bool consoleConect;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        shooting = false;
        interact = false;
        moveRight = false;
        moveLeft = false;
        moveUp = false;
        moveDown = false;
        consoleConect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.None)){}
        if (Input.GetKey(KeyCode.W))
        {
            moveUp = true;
        }
        else { moveUp = false; }
        if (Input.GetKey(KeyCode.S))
        {
            moveDown = true;
        }
        else { moveDown = false; }
        if (Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
        }
        else { moveLeft = false; }
        if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
        }
        else { moveRight = false; }
        if (Input.GetMouseButtonDown(0))
        {
            shooting = true;
        }
        else { shooting = false; }
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact = true;
        }
        else { interact = false; }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            consoleConect = true;
        }
        else { consoleConect = false; }
    }
}
