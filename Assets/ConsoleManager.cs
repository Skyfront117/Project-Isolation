using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Si no está en modo "console", el interactable de los botones tiene que ser false y viceversa.



public class ConsoleManager : MonoBehaviour
{
    public int phase = 0;

    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
    public Text button4Text;


    // Start is called before the first frame update
    void Start()
    {
        button1Text = GetComponent<Text>();
        button2Text = GetComponent<Text>();
        button3Text = GetComponent<Text>();
        button4Text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void onClickButton1()
    {
        System.Console.WriteLine("button1 Clicked");
        if (phase == 0)
        {
            button1Text.text = "5";
            button2Text.text = "6";
            button3Text.text.Replace(button3Text.text,"7");
            button4Text.text = "8";
            phase++;
        }
        else if (phase == 1)
        {

        }
        else if (phase == 2)
        {

        }
        else if (phase == 3)
        {

        }
    }
    public void onClickButton2()
    {
        if (phase == 0)
        {

        }
        else if (phase == 1)
        {

        }
        else if (phase == 2)
        {

        }
        else if (phase == 3)
        {

        }
    }
    public void onClickButton3()
    {
        if (phase == 0)
        {

        }
        else if (phase == 1)
        {

        }
        else if (phase == 2)
        {

        }
        else if (phase == 3)
        {

        }
    }
    public void onClickButton4()
    {
        if (phase == 0)
        {

        }
        else if (phase == 1)
        {

        }
        else if (phase == 2)
        {

        }
        else if (phase == 3)
        {

        }
    }




}
