using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deathScript : MonoBehaviour
{
    public Button exit;
    void Start()
    {

    }

    void Update()
    {

    }

    public void onClickClose()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
