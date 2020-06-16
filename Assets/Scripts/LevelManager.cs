﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    private GameObject Level1Enemies;
    private GameObject Level2Enemies;
    private GameObject Level3Enemies;
    private GameObject LevelDoors;
    public Text objective1;
    public Text objective2;
    public bool level1;
    public bool level2;
    private bool canEnd;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //----> No hay que poner don't destroy porque cuando te vas de la escena de juego queremos que se destruya y generarlo otra vez al entrar al juego
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        level1 = false;
        level2 = false;
        canEnd = false;
        Level1Enemies = GameObject.Find("Level1");
        Level2Enemies = GameObject.Find("Level2");
        Level3Enemies = GameObject.Find("Level3");
        LevelDoors = GameObject.Find("LevelDoors");
    }

    // Update is called once per frame
    void Update()
    {
        //----> También incluimos aqui diálogos etc
        //----> Aquí se lleva todo el loop de los niveles, activar enemigos, abrir/cerrar puertas
        //----> Lo ponemos aqui mejor que en el GameManager, porque así nos ahorramos tener que resetear variables de enemigos, consolas etc etc


        /*
         ----> Nivel 1: Tienes que completar el puzzle de la consola que se encuentra en la sala de mando. Cuando completa el puzzle se llama a la función SaveProgress del GameManager.
         ----> Nivel 2: Tienes que completar el puzzle de la consola del hospital. Cuando completa el puzzle se llama a la función SaveProgress del GameManager.
         ----> Nivel 3: Tienes que ir a la sala grande y activar algo (meter algo en algun pc de allí que active un bool), si ha activado eso tiene que ir a la nave del hangar
                        y realizar un puzzle en la consola de esa nave. (el bool a cambiar se llama SEPUEDEPASARELNIVEL3, si no lo comprendes eres un poco tontito).
                        Cuando completas la consola del nivel 3, como no tenemos más niveles, pasas a la pantalla de victoria.
         */
        if (level1)
        {
            Level2Enemies.SetActive(true);
            Level3Enemies.SetActive(true);
            LevelDoors.SetActive(false);
        }
        else
        {
            Level2Enemies.SetActive(false);
            Level3Enemies.SetActive(false);
        }
        if (level2 || canEnd)
        {
            Level1Enemies.SetActive(false);
        }
        if (!level1)
        {
            objective1.text = "Unlock doors from command bridge";
            objective2.text = "";
        }
        else if (level1)
        {
            if (!level2)
            {
                objective1.text = "Get intel from infirmary";
            }
            else
            {
                objective1.text = "Intel collected";
            }
            if (!canEnd)
            {
                objective2.text = "Deactivate inhibitor from comms room";
            }
            else
            {
                objective2.text = "Inhibitor deactivated";
            }
        }
        if (level1 &&level2 && canEnd)
        {
            objective1.text = "Return to the ship";
            objective2.text = "";
        }
    }

    public void changeLevel2()
    {
        Level1Enemies.SetActive(false);
        Level2Enemies.SetActive(true);
        Level3Enemies.SetActive(false);
    }

    public void changeLevel3()
    {
        //----> Activar el object con el que interactuas(solo el poder interactuar).
        Level1Enemies.SetActive(false);
        Level2Enemies.SetActive(false);
        Level3Enemies.SetActive(true);
    }

    public bool getCanEnd()
    {
        return canEnd;
    }

    public void setEnd(bool state)
    {
        canEnd = state;
    }
}
