﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    private GameObject Level1Enemies;
    private GameObject Level2Enemies;
    private GameObject Level3Enemies;
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
        Level1Enemies = GameObject.Find("Level1");
        Level2Enemies = GameObject.Find("Level2");
        Level3Enemies = GameObject.Find("Level3");
        if(GameManager.instance.levelNum == 1)
        {
            Level1Enemies.SetActive(true);
            Level2Enemies.SetActive(false);
            Level3Enemies.SetActive(false);
        }
        else if(GameManager.instance.levelNum == 2)
        {
            Level1Enemies.SetActive(false);
            Level2Enemies.SetActive(true);
            Level3Enemies.SetActive(false);
        }
        else if (GameManager.instance.levelNum == 3)
        {
            Level1Enemies.SetActive(false);
            Level2Enemies.SetActive(false);
            Level3Enemies.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //----> También incluimos aqui diálogos etc
        //----> Aquí se lleva todo el loop de los niveles, activar enemigos, abrir/cerrar puertas
        //----> Lo ponemos aqui mejor que en el GameManager, porque así nos ahorramos tener que resetear variables de enemigos, consolas etc etc


        /*
         ----> Nivel 1: Tienes que completar el puzzle de la consola que se encuentra en la sala de mando.
         ----> Nivel 2: Tienes que completar el puzzle de la consola del hospital.
         ----> Nivel 3: Tienes que ir a la sala grande y activar algo (meter algo en algun pc de allí que active un bool), si ha activado eso tiene que ir a la nave del hangar
                        y realizar un puzzle en la consola de esa nave. (el bool a cambiar se llama SEPUEDEPASARELNIVEL3, si no lo comprendes eres un poco tontito) 
         */
    }
}
