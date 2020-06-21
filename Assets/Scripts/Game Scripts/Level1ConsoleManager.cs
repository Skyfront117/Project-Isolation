using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Level1ConsoleManager : MonoBehaviour
{
    public string file;
    string[] commandArray;
    public Button[] ButtonsList;
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
    public Text button4Text;

    public Text consoleText;

    private float timerA = 0;
    private float timerB = 0;
    public bool playerConnected;

    public Animator doorAnimator;
     
    public GameObject itemsRadar;
    private GameObject player;

    private int actualPhase;

    private enum status { interactuable, clearing, infected, dropping, shuttingDown, disablingSecurity, hackingCredentials };
    private status actualStatus;
    private bool securityStatus;

    // Start is called before the first frame update
    void Start()
    {
        itemsRadar = GameObject.Find("PickupRadarCollider");
        player = GameObject.Find("Player");
        ReadFromFile();
        ButtonsList = GetComponentsInChildren<Button>(true);
        int length = ButtonsList.Length;
        actualStatus = status.interactuable;
        for (int i = 0; i < length; i++)
        {
            ButtonsList[i].gameObject.SetActive(false);
        }
        button1Text.text = commandArray[0];
        button2Text.text = commandArray[1];
        button3Text.text = commandArray[2];
        button4Text.text = commandArray[3];
        playerConnected = false;
        this.gameObject.SetActive(false);
        SetPhase(0);
        securityStatus = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerConnected)
        {
            player.GetComponent<PlayerController>().canMove = false;
            switch (actualStatus)
            {
                case status.interactuable:
                    break;
                case status.clearing:
                    timerA += Time.deltaTime;
                    if (timerA > 7)
                    {
                        consoleText.text += "\nClear complete!...\n";
                        SetConsoleStatus(status.interactuable);
                        clearScreen();
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
                case status.infected:
                    timerA += Time.deltaTime;
                    if (timerA > 10)
                    {
                        consoleText.text += "\nSystem reboot complete!...\n";
                        SetConsoleStatus(status.interactuable);
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
                case status.dropping:
                    timerA += Time.deltaTime;
                    if (timerA > 10)
                    {
                        consoleText.text += "\nSystem reboot complete!...\n";
                        SetConsoleStatus(status.interactuable);
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
                case status.shuttingDown:
                    timerA += Time.deltaTime;
                    if (timerA > 8)
                    {
                        consoleText.text += "\nSystem Boot complete!...\n";
                        SetConsoleStatus(status.interactuable);
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
                case status.disablingSecurity:
                    timerA += Time.deltaTime;
                    if (timerA > 3)
                    {
                        consoleText.text += "\nSecurity disabled!...\n";
                        SetConsoleStatus(status.interactuable);
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
                case status.hackingCredentials:
                    timerA += Time.deltaTime;
                    if (timerA > 3)
                    {
                        consoleText.text += "\nCredentials successfully hacked!...\n";
                        SetConsoleStatus(status.interactuable);
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
                player.GetComponent<PlayerController>().isHacking = false;
                interactScript.instance.canInteract = false;
                GetComponentInParent<level1Activator>().DisActivateConsole();
            }
        }
    }

    public void clearScreen()
    {
        consoleText.text = "";
    }

    public void OnClickClear()
    {
        SetConsoleStatus(status.clearing);
        SetPhase(0);
        consoleText.text += "\nClearing...\n#";
    }

    public void OnClickButton1()
    {
        consoleText.text += "\n " + button1Text.text;

        switch (actualPhase)
        {
            // BREACH
            case 0:
                SetPhase(1);
                consoleText.text += "\n BREACH: SUCCESS.";
                break;
            // CREDBREACH
            case 1:
                SetConsoleStatus(status.hackingCredentials);
                SetPhase(2);
                break;
            // SECHECK
            case 2:
                consoleText.text += "\n CORRECT CREDENTIALS. ACCESS GRANTED.";
                SetPhase(3);
                break;
            // open
            case 3:
                consoleText.text += "\n SYSTEM ERROR.";
                SetConsoleStatus(status.shuttingDown);
                break;
            // fopen 
            case 4:
                consoleText.text += "\n SYSTEM ERROR.";
                SetConsoleStatus(status.shuttingDown);
                break;
            default:
                break;
        }
    }
    public void OnClickButton2()
    {
        consoleText.text += "\n " + button2Text.text;

        switch (actualPhase)
        {
            // open
            case 0:
                consoleText.text += "\n SYSTEM ERROR.";
                SetConsoleStatus(status.shuttingDown);
                break;
            // shutdown
            case 1:
                SetConsoleStatus(status.shuttingDown);
                break;
            // open
            case 2:
                consoleText.text += "\n SYSTEM ERROR.";
                SetConsoleStatus(status.shuttingDown);
                break;
            // SDISABLE
            case 3:
                securityStatus = false;
                SetPhase(4);
                break;
            // MULTIOPEN
            case 4:
                SetPhase(0);
                OpenDoor();
                break;
            default:
                break;
        }
    }
    public void OnClickButton3()
    {
        consoleText.text += " " + button3Text.text;
        switch (actualPhase)
        {
            // recover
            case 0:
                consoleText.text += "\n SYSTEM ERROR.";
                SetConsoleStatus(status.shuttingDown);
                break;
            // infect
            case 1:
                consoleText.text += "\n ERROR: SYSTEM INFECTED!";
                SetConsoleStatus(status.infected);
                break;
            // SDISABLE
            case 2:
                securityStatus = false;
                SetPhase(4);
                break;
            // close
            case 3:
                consoleText.text += "\n ALL THE DOORS ARE CURRENTLY CLOSED";
                break;
            // shutdown
            case 4:
                consoleText.text += "\n SHUTTING DOWN THE SYSTEM";
                SetConsoleStatus(status.shuttingDown);
                break;
            default:
                break;
        }
    }
    public void OnClickButton4()
    {
        consoleText.text += " " + button4Text.text;
        switch (actualPhase)
        {
            // SUACCES
            case 0:
                consoleText.text += "\n SUACCESS: SUCCESS.";
                SetPhase(1);
                break;
            // open
            case 1:
                consoleText.text += "\n SYSTEM ERROR.";
                SetConsoleStatus(status.shuttingDown);
                break;
            // find
            case 2:
                consoleText.text += "\n SYSTEM ERROR.";
                SetConsoleStatus(status.shuttingDown);
                break;
            // drop
            case 3:
                consoleText.text += "\n SYSTEM ERROR.";
                SetConsoleStatus(status.shuttingDown);
                break;
            // senable
            case 4:
                consoleText.text += "\n SECURITY ENABLE: SUCCESS.";
                securityStatus = true;
                SetPhase(0);
                break;
            default:
                break;
        }
    }

    private void SetConsoleStatus(status _status)
    {
        switch (_status)
        {
            case status.interactuable:
                actualStatus = status.interactuable;
                SetInteractuables(true);
                break;
            case status.clearing:
                SetInteractuables(false);
                timerA = 0;
                timerB = 0;
                SetPhase(0);
                break;
            case status.infected:
                SetInteractuables(false);
                timerA = 0;
                timerB = 0;
                SetPhase(0);
                break;
            case status.dropping:
                SetInteractuables(false);
                timerA = 0;
                timerB = 0;
                SetPhase(0);
                break;
            case status.shuttingDown:
                actualStatus = status.shuttingDown;
                SetInteractuables(false);
                playerConnected = false;
                player.GetComponent<PlayerController>().canMove = true;
                player.GetComponent<PlayerController>().isHacking = false;
                SetPhase(0);
                break;
            case status.disablingSecurity:
                SetInteractuables(false);
                timerA = 0;
                timerB = 0;
                break;
            case status.hackingCredentials:
                SetInteractuables(false);
                timerA = 0;
                timerB = 0;
                break;
            default:
                break;
        }
        actualStatus = _status;
    }

    private void SetPhase(int _phase)
    {
        switch (_phase)
        {
            case 0:
                // BREACH
                button1Text.text = commandArray[0];
                // open
                button2Text.text = commandArray[1];
                // recover
                button3Text.text = commandArray[2];
                // SUACCES
                button4Text.text = commandArray[3];
                break;
            case 1:
                // CREDBREACH
                button1Text.text = commandArray[4];
                // shutdown
                button2Text.text = commandArray[5];
                // infect
                button3Text.text = commandArray[6];
                // sdisable
                button4Text.text = commandArray[7];
                break;
            case 2:
                // SECHECK
                button1Text.text = commandArray[8];
                // open
                button2Text.text = commandArray[9];
                // SDISABLE
                button3Text.text = commandArray[10];
                // find
                button4Text.text = commandArray[11];
                break;
            case 3:
                // open
                button1Text.text = commandArray[12];
                // SDISABLE
                button2Text.text = commandArray[13];
                // close
                button3Text.text = commandArray[14];
                // drop
                button4Text.text = commandArray[15];
                break;
            case 4:
                // fopen 
                button1Text.text = commandArray[16];
                // MULTIOPEN
                button2Text.text = commandArray[17];
                // shutdown
                button3Text.text = commandArray[18];
                // senable
                button4Text.text = commandArray[19];
                break;
            //case 5:
            //    // OPEN
            //    button1Text.text = commandArray[20];
            //    // close
            //    button2Text.text = commandArray[21];
            //    // renable
            //    button3Text.text = commandArray[22];
            //    // secheck
            //    button4Text.text = commandArray[23];
            //    break;
            //case 6:
            //    // 1267
            //    button1Text.text = commandArray[24];
            //    // 23
            //    button2Text.text = commandArray[25];
            //    // 970
            //    button3Text.text = commandArray[26];
            //    // 58
            //    button4Text.text = commandArray[27];
            //    break;
            default:
                break;
        }
        actualPhase = _phase;
    }

    private void SetInteractuables(bool _value)
    {
        int length = ButtonsList.Length;
        for (int i = 0; i < length; i++)
        {
            ButtonsList[i].interactable = _value;
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

    private void OpenDoor()
    {
        SetConsoleStatus(0);
        playerConnected = false;
        player.GetComponent<PlayerController>().canMove = true;
        player.GetComponent<PlayerController>().isHacking = false;
        GetComponentInParent<level1Activator>().DisActivateConsole();
        LevelManager.Instance.level1 = true;
        Destroy(this.gameObject);
    }
}
