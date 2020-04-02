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
    private float timer = 0;
    private enum tutorialPhase { dialogue1, dialogue2, dialogue3, dialogue4, dialogue5, dialogue6, dialogue7, dialogue8, dialogue9,
        staticSingleEnemy, dialogue10, dialogue11, staticEnemies, dialogue12, dialogue13, dialogue14, dialogue15, dialogue16, dialogue17,
        dialogue18, dialogue19, dialogue20, dialogue21, movingEnemie, dialogue22, dialogue23, dialogue24, dialogue25, levelLearning
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
    private Queue<string> sentences;
    public TextMeshProUGUI dialogueText;
    public Image speakingCharacterImage;
    private bool dialogueEnded = false;

    public GameObject[] aEnemies;
    public GameObject TutorialEnemy1;
    public GameObject TutorialEnemy2;
    public GameObject TutorialEnemy3;

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
        actualPhase = tutorialPhase.dialogue1;
        StartDialogue(dialogue1);
    }

    // Update is called once per frame
    void Update()
    {
        switch (actualPhase)
        {
            case tutorialPhase.dialogue1:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.interact)
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
                if (InputManager.Instance.interact)
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
                if (InputManager.Instance.interact)
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
                if (InputManager.Instance.interact)
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
                if (InputManager.Instance.interact)
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
                if (InputManager.Instance.interact)
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
                if (InputManager.Instance.interact)
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
                if (InputManager.Instance.interact)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        StartDialogue(dialogue9);
                    }
                    else
                    {
                        DisplayNextSentence();
                    }
                }
                break;
            case tutorialPhase.dialogue9:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.interact)
                {
                    if (dialogueEnded)
                    {
                        dialogueEnded = false;
                        actualPhase++;
                        // ¿Oscurecer chat?
                        InstantiateEnemies1();
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
                if (InputManager.Instance.interact)
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
                if (InputManager.Instance.interact)
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
                if (timer < 10 || enemiesCount == 0)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    switch (enemiesCount)
                    {
                        case 0:
                            actualPhase = tutorialPhase.dialogue12;
                            StartDialogue(dialogue12);
                            break;
                        case 1:
                        case 2:
                            actualPhase = tutorialPhase.dialogue15;
                            StartDialogue(dialogue15);
                            break;
                        case 3:
                            actualPhase = tutorialPhase.dialogue18;
                            StartDialogue(dialogue18);
                            break;
                        default:
                            break;
                    }
                }
                break;
            case tutorialPhase.dialogue12:
                player.GetComponent<PlayerController>().canMove = false;
                if (InputManager.Instance.interact)
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
                break;
            case tutorialPhase.dialogue14:
                break;
            case tutorialPhase.dialogue15:
                break;
            case tutorialPhase.dialogue16:
                break;
            case tutorialPhase.dialogue17:
                break;
            case tutorialPhase.dialogue18:
                break;
            case tutorialPhase.dialogue19:
                break;
            case tutorialPhase.dialogue20:
                break;
            case tutorialPhase.dialogue21:
                break;
            case tutorialPhase.movingEnemie:
                break;
            case tutorialPhase.dialogue22:
                break;
            case tutorialPhase.dialogue23:
                break;
            case tutorialPhase.dialogue24:
                break;
            case tutorialPhase.dialogue25:
                break;
            case tutorialPhase.levelLearning:
                break;
            default:
                break;
        }

        //if (dialogueEnded)
        //{
        //    dialogueEnded = false;
        //    actualPhase++;
        //}
    }

public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.characterTalkingImage.ToString());

        speakingCharacterImage.sprite = dialogue.characterTalkingImage;

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
        positionTemp.Set(-4648, 4186, -0.1f);

        aEnemies[0] = Instantiate(TutorialEnemy1);
        aEnemies[0].transform.position = positionTemp;
    }

    private void InstantiateEnemies2()
    {
        Vector3 positionTemp = new Vector3();
        aEnemies = new GameObject[3];

        aEnemies[0] = Instantiate(TutorialEnemy1);
        positionTemp.Set(-4648, 4186, -0.1f);
        aEnemies[0].transform.position = positionTemp;

        aEnemies[1] = Instantiate(TutorialEnemy1);
        positionTemp.Set(-4966, 3804, -0.1f);
        aEnemies[1].transform.position = positionTemp;

        aEnemies[2] = Instantiate(TutorialEnemy1);
        positionTemp.Set(-4385, 3802, -0.1f);
        aEnemies[2].transform.position = positionTemp;
    }
}