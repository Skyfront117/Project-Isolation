using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ConsoleManager : MonoBehaviour
{
    public string file;
    string[] commandArray;


    public int phase = 0;
    public Button[] ButtonsList;
    public GameObject ConsoleText;
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
    public Text button4Text;

    public Text consoleText;

    private float timerA = 0;
    private float timerB = 0;
    public bool playerConnected;

    private string finalString;
    private string correctAnswer;

    public Animator doorAnimator;

    public GameObject itemsRadar;
    private GameObject player;

    private int status = 1; //1 = Disponible para interactuar; 2 = clearing;

    void Start()
    {
        itemsRadar = GameObject.Find("PickupRadarCollider");
        player = GameObject.Find("Player");
        ReadFromFile();
        ButtonsList = GetComponentsInChildren<Button>(true);
        int length = ButtonsList.Length;
        for (int i = 0; i < length; i++)
        {
            ButtonsList[i].gameObject.SetActive(false);
        }
        button1Text.text = commandArray[0];
        button2Text.text = commandArray[1];
        button3Text.text = commandArray[2];
        button4Text.text = commandArray[3];
        playerConnected = false;
        correctAnswer = "07323759";
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerConnected)
        {
            switch (status)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    timerA += Time.deltaTime;
                    if (timerA > 10)
                    {
                        consoleText.text += "\nClear complete!...\n";
                        SetConsoleStatus(1);
                    }
                    else
                    {
                        if ((timerA - timerB) > 1)
                        {
                            consoleText.text += "#";
                            timerB = timerA;
                        }
                    }
                    break;
                default:
                    break;
            }

            if (InputManager.Instance.consoleDisconect)
            {
                playerConnected = false;
                player.GetComponent<PlayerController>().canMove = true;
                itemsRadar.GetComponent<ItemsRadarScript>().ConsoleManager = null;
                GetComponentInParent<DoorScript>().DisActivateConsole();
            }
        }
    }

    public void OnClickButton1()
    {
        consoleText.text += " " + button1Text.text;
        finalString += button1Text.text;

        if (phase == 0)
        {
            button1Text.text = commandArray[4];
            button2Text.text = commandArray[5];
            button3Text.text = commandArray[6];
            button4Text.text = commandArray[7];
            phase++;
        }
        else if (phase == 1)
        {
            button1Text.text = commandArray[20];
            button2Text.text = commandArray[21];
            button3Text.text = commandArray[22];
            button4Text.text = commandArray[23];
            phase++;
        }
        else if (phase == 2)
        {
            button1Text.text = commandArray[36];
            button2Text.text = commandArray[37];
            button3Text.text = commandArray[38];
            button4Text.text = commandArray[39];
            phase++;
        }
        else if (phase == 3)
        {
            button1Text.text = commandArray[52];
            button2Text.text = commandArray[53];
            button3Text.text = commandArray[54];
            button4Text.text = commandArray[55];
            phase++;
        }
        else if (phase == 4)
        {
            Compare();
        }
    }
    public void OnClickButton2()
    {
        consoleText.text += " " + button2Text.text;
        finalString += button2Text.text;

        if (phase == 0)
        {
            button1Text.text = commandArray[8];
            button2Text.text = commandArray[9];
            button3Text.text = commandArray[10];
            button4Text.text = commandArray[11];
            phase++;
        }
        else if (phase == 1)
        {
            button1Text.text = commandArray[24];
            button2Text.text = commandArray[25];
            button3Text.text = commandArray[26];
            button4Text.text = commandArray[27];
            phase++;
        }
        else if (phase == 2)
        {
            button1Text.text = commandArray[40];
            button2Text.text = commandArray[41];
            button3Text.text = commandArray[42];
            button4Text.text = commandArray[43];
            phase++;
        }
        else if (phase == 3)
        {
            button1Text.text = commandArray[56];
            button2Text.text = commandArray[57];
            button3Text.text = commandArray[58];
            button4Text.text = commandArray[59];
            phase++;
        }
        else if (phase == 4)
        {
            Compare();
        }
    }
    public void OnClickButton3()
    {
        consoleText.text += " " + button3Text.text;
        finalString += button3Text.text;

        if (phase == 0)
        {
            button1Text.text = commandArray[12];
            button2Text.text = commandArray[13];
            button3Text.text = commandArray[14];
            button4Text.text = commandArray[15];
            phase++;
        }
        else if (phase == 1)
        {
            button1Text.text = commandArray[28];
            button2Text.text = commandArray[29];
            button3Text.text = commandArray[30];
            button4Text.text = commandArray[31];
            phase++;
        }
        else if (phase == 2)
        {
            button1Text.text = commandArray[44];
            button2Text.text = commandArray[45];
            button3Text.text = commandArray[46];
            button4Text.text = commandArray[47];
            phase++;
        }
        else if (phase == 3)
        {
            button1Text.text = commandArray[60];
            button2Text.text = commandArray[61];
            button3Text.text = commandArray[62];
            button4Text.text = commandArray[63];
            phase++;
        }
        else if (phase == 4)
        {
            Compare();
        }
    }
    public void OnClickButton4()
    {
        consoleText.text += " " + button4Text.text;
        finalString += button4Text.text;

        if (phase == 0)
        {
            button1Text.text = commandArray[16];
            button2Text.text = commandArray[17];
            button3Text.text = commandArray[18];
            button4Text.text = commandArray[19]; 
            phase++;
        }
        else if (phase == 1)
        {
            button1Text.text = commandArray[32];
            button2Text.text = commandArray[33];
            button3Text.text = commandArray[34];
            button4Text.text = commandArray[35];
            phase++;
        }
        else if (phase == 2)
        {
            button1Text.text = commandArray[48];
            button2Text.text = commandArray[49];
            button3Text.text = commandArray[50];
            button4Text.text = commandArray[51];
            phase++;
        }
        else if (phase == 3)
        {
            button1Text.text = commandArray[64];
            button2Text.text = commandArray[65];
            button3Text.text = commandArray[66];
            button4Text.text = commandArray[67];
            phase++;
        }
        else if (phase == 4)
        {
            Compare();
        }
    }

    public void OnClickClear()
    {
        SetConsoleStatus(2);
        button1Text.text = commandArray[0];
        button2Text.text = commandArray[1];
        button3Text.text = commandArray[2];
        button4Text.text = commandArray[3];
        consoleText.text += "\nClearing...\n#";
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
                status = 0;
                SetInteractuables(false);
                playerConnected = false;
                break;
            case 1:
                status = 1;
                SetInteractuables(true);
                break;
            case 2:
                status = 2;
                SetInteractuables(false);
                timerA = 0;
                timerB = 0;
                phase = 0;
                finalString = "";
                break;

            default:
                break;
        }
    }

    public int GetStatus() { return status; }

    void SetInteractuables(bool _value)
    {
        int length = ButtonsList.Length;
        for (int i = 0; i < length; i++)
        {
            ButtonsList[i].interactable = _value;
        }
    }

    void Compare()
    {
        if (finalString == correctAnswer)
        {
            //doorAnimator.SetBool("open", true);
            SetConsoleStatus(0);
            playerConnected = false;
            player.GetComponent<PlayerController>().canMove = true;
            itemsRadar.GetComponent<ItemsRadarScript>().ConsoleManager = null;
            GetComponentInParent<DoorScript>().DisActivateConsole();
            GetComponentInParent<DoorScript>().OpenDoor();
        }
        else
        {
            consoleText.text += "\nFATAL ERROR\n";
            OnClickClear();
        }
    }

    public void setButtonsActives(bool _value)
    {
        foreach (var item in ButtonsList)
        {
            item.gameObject.SetActive(_value);
        }
        consoleText.gameObject.SetActive(_value);
    }


    public void ReadFromFile()
    {
        TextAsset line = Resources.Load<TextAsset>(file);
        commandArray = line.text.Split(';');
    }
}