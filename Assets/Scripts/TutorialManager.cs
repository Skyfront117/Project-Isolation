using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }
    private GameObject player;
    public int enemiesCount = 0;
    public float timer = 0;
    private float timer2 = 0;
    private enum tutorialPhase { dialogue1, dialogue2, dialogue3, dialogue4, dialogue5, dialogue6, dialogue7, dialogue8, dialogue9,
        staticSingleEnemy, dialogue10, dialogue11, staticEnemies, dialogue12, dialogue13, dialogue14, dialogue15, dialogue16, dialogue17,
        dialogue18, dialogue19, dialogue20, dialogue21, movingEnemy, dialogue22, dialogue23, dialogue24, dialogue25, levelLearning, dialogue26,
        dialogue27, dialogue28, dialogue29, dialogue30, dialogue31, dialogue32, dialogue33, dialogue34, dialogue35, dialogue36, dialogue37,
        dialogue38, dialogue39, dialogue40, dialogue41, dialogue42, dialogue43, dialogue44
    };
    private tutorialPhase actualPhase;
    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    public Dialogue dialogue4;
    public Dialogue dialogue5;
    public Dialogue dialogue6;
    public Dialogue dialogue7;
    public Dialogue dialogue8;
    public Dialogue dialogue9;
    public Dialogue dialogue10;
    public Dialogue dialogue11;
    public Dialogue dialogue12;
    public Dialogue dialogue13;
    public Dialogue dialogue14;
    public Dialogue dialogue15;
    public Dialogue dialogue16;
    public Dialogue dialogue17;
    public Dialogue dialogue18;
    public Dialogue dialogue19;
    public Dialogue dialogue20;
    public Dialogue dialogue21;
    public Dialogue dialogue22;
    public Dialogue dialogue23;
    public Dialogue dialogue24;
    public Dialogue dialogue25;
    public Dialogue dialogue26;
    public Dialogue dialogue27;
    public Dialogue dialogue28;
    public Dialogue dialogue29;
    public Dialogue dialogue30;
    public Dialogue dialogue31;
    public Dialogue dialogue32;
    public Dialogue dialogue33;
    public Dialogue dialogue34;
    public Dialogue dialogue35;
    public Dialogue dialogue36;
    public Dialogue dialogue37;
    public Dialogue dialogue38;
    public Dialogue dialogue39;
    public Dialogue dialogue40;
    public Dialogue dialogue41;
    public Dialogue dialogue42;
    public Dialogue dialogue43;
    public Dialogue dialogue44;
    private Queue<string> sentences;
    public TextMeshProUGUI speakingCharacterName;
    public TextMeshProUGUI dialogueText;
    public Image speakingCharacterImage;
    private bool dialogueEnded = false;

    public GameObject[] aEnemies;
    public GameObject TutorialEnemy1;
    public GameObject TutorialEnemy2;
    public GameObject TutorialEnemy3;

    private bool firstEnemyShootingBool = false;
    private bool doorTutorialBool = false;
    private bool linkConsoleBool = false;
    private bool firstComandError = false;

    private int consoleErrorsCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        sentences = new Queue<string>();
        actualPhase = tutorialPhase.dialogue1; //dialogue1
        StartDialogue(dialogue1);
    }

    // Update is called once per frame
    void Update()
    {

        switch (actualPhase)
        {
            case tutorialPhase.dialogue1:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        StartDialogue(dialogue2);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue2:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        StartDialogue(dialogue3);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue3:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        StartDialogue(dialogue4);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue4:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        StartDialogue(dialogue5);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue5:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        StartDialogue(dialogue6);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue6:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        StartDialogue(dialogue7);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue7:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        StartDialogue(dialogue8);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue8:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        StartDialogue(dialogue9);
                        InstantiateEnemies1();
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue9:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.staticSingleEnemy:
                player.GetComponent<PlayerController>().canMove = true;
                if (enemiesCount < 1)
                {
                    actualPhase++;
                    StartDialogue(dialogue10);
                }
                break;
            case tutorialPhase.dialogue10:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue11);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue11:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        InstantiateEnemies2();
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.staticEnemies:
                player.GetComponent<PlayerController>().canMove = true;
                timer += Time.deltaTime;
                if (enemiesCount == 0 || timer > 10)
                {
                    enemiesCount = 0;
                    foreach (GameObject enemy in aEnemies)
                    {
                        if (enemy != null)
                        {
                            enemy.GetComponent<Animator>().SetTrigger(Animator.StringToHash("Die"));
                        }
                    }
                    timer = 0;
                    if (timer2 < 0.25)
                    {
                        timer2 += Time.deltaTime;
                    }
                    else
                    {
                        switch (enemiesCount)
                        {
                            case 3:
                                actualPhase = tutorialPhase.dialogue12;
                                StartDialogue(dialogue12);
                                break;
                            case 1:
                            case 2:
                                actualPhase = tutorialPhase.dialogue15;
                                StartDialogue(dialogue15);
                                break;
                            case 0:
                                actualPhase = tutorialPhase.dialogue18;
                                StartDialogue(dialogue18);
                                break;
                            default:
                                break;
                        }
                        foreach (GameObject enemy in aEnemies)
                        {
                            Destroy(enemy.gameObject);
                        }
                        aEnemies = new GameObject[0];
                    }
                }
                break;
            case tutorialPhase.dialogue12:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue13);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue13:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue14);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue14:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase = tutorialPhase.dialogue21;
                        // ¿Oscurecer chat?
                        InstantiateMovingEnemy();
                        StartDialogue(dialogue21);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue15:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue16);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue16:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue17);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue17:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase = tutorialPhase.dialogue21;
                        // ¿Oscurecer chat?
                        InstantiateMovingEnemy();
                        StartDialogue(dialogue21);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue18:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue19);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue19:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue20);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue20:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        InstantiateMovingEnemy();
                        StartDialogue(dialogue21);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue21:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.movingEnemy:
                player.GetComponent<PlayerController>().canMove = true;
                if (enemiesCount < 1)
                {
                    actualPhase++;
                    StartDialogue(dialogue22);
                }
                break;
            case tutorialPhase.dialogue22:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue23);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue23:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue24);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue24:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue25);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue25:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartLevelLearning();
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.levelLearning:
                player.GetComponent<PlayerController>().canMove = true;
                break;
            case tutorialPhase.dialogue26:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue27);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue27:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue28);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue28:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue29);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue29:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue30);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue30:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue31);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue31:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue32);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue32:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue33);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue33:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue34);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue34:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue35);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue35:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue36);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue36:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue37);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue37:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue38);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue38:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue39);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue39:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue40);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue40:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue41);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue41:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue42);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue42:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue43);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue43:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.nextXat)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        StartDialogue(dialogue44);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue44:
                break;
            default:
                break;
        }
    }

public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.characterTalkingImage.ToString());

        speakingCharacterImage.sprite = dialogue.characterTalkingImage;
        speakingCharacterName.text = dialogue.characterName;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        if (sentences.Count == 0)
        {
            dialogueEnded = true;
            return;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void InstantiateEnemies1()
    {
        aEnemies = new GameObject[1];
        enemiesCount = 1;
        Vector3 positionTemp = new Vector3();
        positionTemp.Set(-3251, 3800, -0.1f);

        aEnemies[0] = Instantiate(TutorialEnemy1);
        aEnemies[0].transform.position = positionTemp;
    }

    private void InstantiateEnemies2()
    {
        Vector3 positionTemp = new Vector3();
        aEnemies = new GameObject[3];
        enemiesCount = 3;
        aEnemies[0] = Instantiate(TutorialEnemy1);
        positionTemp.Set(-3251, 3800, -0.1f);
        aEnemies[0].transform.position = positionTemp;

        aEnemies[1] = Instantiate(TutorialEnemy1);
        positionTemp.Set(-3100, 3800, -0.1f);
        aEnemies[1].transform.position = positionTemp;

        aEnemies[2] = Instantiate(TutorialEnemy1);
        positionTemp.Set(-3400, 3800, -0.1f);
        aEnemies[2].transform.position = positionTemp;
    }

    private void InstantiateMovingEnemy()
    {
        aEnemies = new GameObject[1];
        enemiesCount = 1;
        Vector3 positionTemp = new Vector3();
        positionTemp.Set(-3400, 3800, -0.1f);

        aEnemies[0] = Instantiate(TutorialEnemy2);
        aEnemies[0].transform.position = positionTemp;
    }

    private void StartLevelLearning()
    {
        player.transform.position = new Vector2(GameObject.Find("Room2PlayerTransform").transform.position.x, GameObject.Find("Room2PlayerTransform").transform.position.y);

        aEnemies = new GameObject[3];
        enemiesCount = 3;

        Vector3 positionTemp = new Vector3();
        aEnemies[0] = Instantiate(TutorialEnemy3);
        positionTemp.Set(968.6031f, 640.7841f, -0.1f);
        aEnemies[0].transform.position = positionTemp;

        aEnemies[1] = Instantiate(TutorialEnemy3);
        positionTemp.Set(-632, -552, -0.1f);
        aEnemies[1].transform.position = positionTemp;

        aEnemies[2] = Instantiate(TutorialEnemy3);
        positionTemp.Set(430, -552, -0.1f);
        aEnemies[2].transform.position = positionTemp;
    }

    public void dialogueFirstEnemyShooting()
    {
        if (!firstEnemyShootingBool)
        {
            StartDialogue(dialogue26);
            firstEnemyShootingBool = true;
        }
    }

    public void DoorTutorial()
    {
        if (!doorTutorialBool)
        {
            StartDialogue(dialogue30);
            doorTutorialBool = true;
        }
    }
    
    public void FirstTimeOnConsole()
    {
        if (!linkConsoleBool)
        {
            StartDialogue(dialogue31);
            linkConsoleBool = true;
        }
    }

    public void ComandErrorDialogue()
    {
        if (!firstComandError)
        {
            StartDialogue(dialogue33);
            firstComandError = true;
        }
        consoleErrorsCount++;
    }
}