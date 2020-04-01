using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }
    private GameObject player;
    public int enemiesCount = 4;
    private enum tutorialPhase { dialogue1, staticEnemies, movingEnemies, normalEnemies, levelLearning};
    private tutorialPhase actualPhase = tutorialPhase.staticEnemies;
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
        StartDialogue(dialogue1);
    }

    // Update is called once per frame
    void Update()
    {
        switch (actualPhase)
        {
            case tutorialPhase.dialogue1:
                player.GetComponent<PlayerController>().canMove = false;
                break;
            case tutorialPhase.staticEnemies:
                if (enemiesCount < 1)
                {
                    player.GetComponent<PlayerController>().canMove = true;
                    actualPhase++;
                }
                break;
            case tutorialPhase.movingEnemies:
                if (enemiesCount < 1)
                {
                    actualPhase++;
                }
                break;
            case tutorialPhase.normalEnemies:
                break;
            case tutorialPhase.levelLearning:
                break;
            default:
                break;
        }
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
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
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
        Vector3 positionTemp = new Vector3();
        positionTemp.Set(-4648, 4186, 0);

        aEnemies[0] = Instantiate(TutorialEnemy1);
        aEnemies[0].transform.position = positionTemp;
    }

    private void InstantiateEnemies2()
    {
        Vector3 positionTemp = new Vector3();
        aEnemies = new GameObject[3];

        aEnemies[0] = Instantiate(TutorialEnemy1);
        positionTemp.Set(-4648, 4186, 0);
        aEnemies[0].transform.position = positionTemp;

        aEnemies[1] = Instantiate(TutorialEnemy1);
        positionTemp.Set(-4966, 3804, 0);
        aEnemies[1].transform.position = positionTemp;

        aEnemies[2] = Instantiate(TutorialEnemy1);
        positionTemp.Set(-4385, 3802, 0);
        aEnemies[2].transform.position = positionTemp;
    }

    void EndDialogue()
    {
        Debug.Log("Ending dialogue.");
    }

}