using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score;
    public int playerHP;
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
        score = 100;
        playerHP = 50;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(score);
        if(playerHP <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }
}
