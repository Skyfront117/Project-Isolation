using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }
    public GameObject dialoguesCanvas;
    private GameObject player;
    public int enemiesCount = 0;
    public float timer = 0;
    private float timer2 = 0;
    public float displayTextTime;
    private float maxDisplayTextTime;
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
        displayTextTime = 0.0f;
        maxDisplayTextTime = 3.0f;
        player = GameObject.Find("Player");
        sentences = new Queue<string>();
        actualPhase = tutorialPhase.dialogue1; //dialogue1
        StartDialogue(dialogue1);
    }

    void hideDialogue()
    {
        if (dialoguesCanvas.active)
        {
            Debug.Log("adding time");
            displayTextTime += Time.deltaTime;
            if (displayTextTime >= maxDisplayTextTime)
            {
                Debug.Log("XD");
                displayTextTime = 0;

                dialoguesCanvas.SetActive(false);
            }
        }
        else
        {
            displayTextTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(displayTextTime != 0)
        {
            SoundManager.Instance.audio.enabled = true;
        }
        switch (actualPhase)
        {
            case tutorialPhase.dialogue1:
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                hideDialogue();
                if (enemiesCount < 1)
                {
                    actualPhase++;
                    StartDialogue(dialogue10);
                }
                break;
            case tutorialPhase.dialogue10:
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                hideDialogue();
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
                else
                {
                    //mostrar valor de la variable timer
                    //Text timerPrint = Instantiate<Text>();
                    //timerPrint.text = timer.ToString();
                }
                break;
            case tutorialPhase.dialogue12:
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                hideDialogue();
                if (enemiesCount < 1)
                {
                    actualPhase++;
                    StartDialogue(dialogue22);
                }
                break;
            case tutorialPhase.dialogue22:
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                hideDialogue();
                break;
            case tutorialPhase.dialogue26:
                dialoguesCanvas.SetActive(true);
                hideDialogue();
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                dialoguesCanvas.SetActive(true);
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
                hideDialogue();
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
        dialoguesCanvas.SetActive(true);
        displayTextTime = 0;
        string sentence = sentences.Dequeue();
        SoundManager.Instance.audio.enabled = false;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        if (sentences.Count == 0)
        {
            dialogueEnded = true;
            return;
        }
        hideDialogue();
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
        positionTemp.Set(-444.8f, 535.3f, -0.1f);

        aEnemies[0] = Instantiate(TutorialEnemy1);
        aEnemies[0].transform.position = positionTemp;
    }

    private void InstantiateEnemies2()
    {
        Vector3 positionTemp = new Vector3();
        aEnemies = new GameObject[3];
        enemiesCount = 3;
        aEnemies[0] = Instantiate(TutorialEnemy1);
        positionTemp.Set(-481.4f, 519.9f, -0.1f);
        aEnemies[0].transform.position = positionTemp;

        aEnemies[1] = Instantiate(TutorialEnemy1);
        positionTemp.Set(-444.8f, 535.3f, -0.1f);
        aEnemies[1].transform.position = positionTemp;

        aEnemies[2] = Instantiate(TutorialEnemy1);
        positionTemp.Set(-389.8f, 535.3f, -0.1f);
        aEnemies[2].transform.position = positionTemp;
    }

    private void InstantiateMovingEnemy()
    {
        aEnemies = new GameObject[1];
        enemiesCount = 1;
        Vector3 positionTemp = new Vector3();
        positionTemp.Set(-444.8f, 535.3f, -0.1f);

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
        positionTemp.Set(-141.4f, -83.6f, -0.1f);
        aEnemies[0].transform.position = positionTemp;

        aEnemies[1] = Instantiate(TutorialEnemy3);
        positionTemp.Set(157.5f, -100.3f, -0.1f);
        aEnemies[1].transform.position = positionTemp;

        aEnemies[2] = Instantiate(TutorialEnemy3);
        positionTemp.Set(85.7f, 107.3f, -0.1f);
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