using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int score = 1000;

    public float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 120)
        {
            score--;
        }
    }
}