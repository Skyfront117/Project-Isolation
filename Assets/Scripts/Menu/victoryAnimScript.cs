using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class victoryAnimScript : MonoBehaviour
{
    public Text rank;
    public Text score;
    public Text taunt;
    // Start is called before the first frame update
    void Start()
    {
        score.text = GameManager.instance.score.ToString("0");
        if (GameManager.instance.score <= 10000 && GameManager.instance.score > 8000)
        {
            rank.text = "S";
            taunt.text = "You're pretty good";
            SoundManager.Instance.PlayPrettyGood();
        }
        else if (GameManager.instance.score <= 8000 && GameManager.instance.score > 6000)
        {
            rank.text = "A";
            taunt.text = "Remarkable performance, soldier";
            SoundManager.Instance.PlayRemarkable();
        }
        else if (GameManager.instance.score <= 6000 && GameManager.instance.score > 4000)
        {
            rank.text = "B";
            taunt.text = "Not that bad, actually";
            SoundManager.Instance.PlayActually();
        }
        else if (GameManager.instance.score <= 4000 && GameManager.instance.score > 2000)
        {
            rank.text = "C";
            taunt.text = "At least you survived";
            SoundManager.Instance.PlaySurvive();
        }
        if (GameManager.instance.score <= 2000 && GameManager.instance.score >= 0)
        {
            rank.text = "D";
            taunt.text = "What a human waste you are";
            SoundManager.Instance.PlayHumanWaste();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToMenu()
    {
        GameManager.instance.score = 10000;
        SceneManager.LoadScene("MainMenu");
    }
}
