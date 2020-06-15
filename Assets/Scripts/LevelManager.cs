using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

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
        
    }

    // Update is called once per frame
    void Update()
    {
        //----> También incluimos aqui diálogos etc
        //----> Aquí se lleva todo el loop de los niveles, activar enemigos, abrir/cerrar puertas
        //----> Lo ponemos aqui mejor que en el GameManager, porque así nos ahorramos tener que resetear variables de enemigos, consolas etc etc
    }
}
