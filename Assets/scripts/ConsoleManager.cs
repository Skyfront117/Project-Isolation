using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Si no está en modo "console", el interactable de los botones tiene que ser false y viceversa.



public class ConsoleManager : MonoBehaviour
{
    public int phase = 0;
    Button[] ButtonsList;
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
    public Text button4Text;

    public Text consoleText;

    private float timer = 0;
    private bool playerConnected = true; // Test, debería ser false.

    private int status = 1; // 0 = apagado; 1 = Disponible para interactuar; 2 = clearing;

    void Start()
    {
        ButtonsList = GetComponentsInChildren<Button>();
        button1Text.text = "0";
        button2Text.text = "1";
        button3Text.text = "2";
        button4Text.text = "3";
        SetConsoleStatus(1); //Test
    }

    private void Update()
    {
        if (playerConnected)
        {
            timer += Time.deltaTime;

            switch (status)
            {
                case 0:
                    break;
                case 1:

                    break;
                case 2:
                    if (timer > 5)
                    {
                        SetConsoleStatus(1);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void OnClickButton1()
    {
        consoleText.text += " " + button1Text.text;

        if (phase == 0)
        {
            button1Text.text = "4";
            button2Text.text = "5";
            button3Text.text = "6";
            button4Text.text = "7";
            phase++;
        }
        else if (phase == 1)
        {
            button1Text.text = "20";
            button2Text.text = "21";
            button3Text.text = "21";
            button4Text.text = "23";
            phase++;
        }
        else if (phase == 2)
        {
            button1Text.text = "36";
            button2Text.text = "37";
            button3Text.text = "38";
            button4Text.text = "39";
            phase++;
        }
        else if (phase == 3)
        {
            button1Text.text = "52";
            button2Text.text = "53";
            button3Text.text = "54";
            button4Text.text = "55";
            phase++;
        }
    }
    public void OnClickButton2()
    {
        consoleText.text += " " + button2Text.text;

        if (phase == 0)
        {
            button1Text.text = "8";
            button2Text.text = "9";
            button3Text.text = "10";
            button4Text.text = "11";
            phase++;
        }
        else if (phase == 1)
        {
            button1Text.text = "24";
            button2Text.text = "25";
            button3Text.text = "26";
            button4Text.text = "27";
            phase++;
        }
        else if (phase == 2)
        {
            button1Text.text = "40";
            button2Text.text = "41";
            button3Text.text = "42";
            button4Text.text = "43";
            phase++;
        }
        else if (phase == 3)
        {
            button1Text.text = "56";
            button2Text.text = "57";
            button3Text.text = "58";
            button4Text.text = "59";
            phase++;
        }
    }
    public void OnClickButton3()
    {
        consoleText.text += " " + button3Text.text;
        if (phase == 0)
        {
            button1Text.text = "12";
            button2Text.text = "13";
            button3Text.text = "14";
            button4Text.text = "15";
            phase++;
        }
        else if (phase == 1)
        {
            button1Text.text = "28";
            button2Text.text = "29";
            button3Text.text = "30";
            button4Text.text = "31";
            phase++;
        }
        else if (phase == 2)
        {
            button1Text.text = "44";
            button2Text.text = "45";
            button3Text.text = "46";
            button4Text.text = "47";
            phase++;
        }
        else if (phase == 3)
        {
            button1Text.text = "60";
            button2Text.text = "61";
            button3Text.text = "62";
            button4Text.text = "63";
            phase++;
        }
    }
    public void OnClickButton4()
    {
        consoleText.text += " " + button4Text.text;
        if (phase == 0)
        {
            button1Text.text = "16";
            button2Text.text = "17";
            button3Text.text = "18";
            button4Text.text = "19"; 
            phase++;
        }
        else if (phase == 1)
        {
            button1Text.text = "32";
            button2Text.text = "33";
            button3Text.text = "34";
            button4Text.text = "35";
            phase++;
        }
        else if (phase == 2)
        {
            button1Text.text = "48";
            button2Text.text = "49";
            button3Text.text = "50";
            button4Text.text = "51";
            phase++;
        }
        else if (phase == 3)
        {
            button1Text.text = "64";
            button2Text.text = "65";
            button3Text.text = "66";
            button4Text.text = "67";
            phase++;
        }
    }

    public void OnClickClear()
    {
        SetConsoleStatus(2);
        button1Text.text = "0";
        button2Text.text = "1";
        button3Text.text = "2";
        button4Text.text = "3";
        consoleText.text += "\nFlushing...\n";
    }

    public void SetConsoleStatus(int _status)
    {
        // Comprobación development:
        if (_status < 0 || _status > 2)
        {
            Debug.Log("SetConsoleStatus Error _status out of valid range.");
            return;
        }

        switch (_status)
        {
            case 0:
                SetInteractuables(false);
                break;
            case 1:
                SetInteractuables(true);
                break;
            case 2:
                SetInteractuables(false);
                timer = 0;
                phase = 0;
                break;

            default:
                break;
        }

    }

    void SetInteractuables(bool _value)
    {
        foreach (var item in ButtonsList)
        {
            item.interactable = _value;
        }
    }
}