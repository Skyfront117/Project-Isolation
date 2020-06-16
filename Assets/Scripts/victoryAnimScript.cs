using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victoryAnimScript : MonoBehaviour
{
    public Text rank;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.score <= 10000 && GameManager.instance.score > 8000)
        {
            rank.text = "S";
        }
        else if (GameManager.instance.score <= 8000 && GameManager.instance.score > 6000)
        {
            rank.text = "A";
        }
        else if (GameManager.instance.score <= 6000 && GameManager.instance.score > 4000)
        {
            rank.text = "B";
        }
        else if (GameManager.instance.score <= 4000 && GameManager.instance.score > 2000)
        {
            rank.text = "C";
        }
        if (GameManager.instance.score <= 2000 && GameManager.instance.score >= 0)
        {
            rank.text = "D";
        }
    }
}
