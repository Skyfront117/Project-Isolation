using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }
    private GameObject player;
    public int enemiesCount = 4;
    private enum tutorialPhase { dialogue1, staticEnemies, movingEnemies, normalEnemies, levelLearning};
    private tutorialPhase actualPhase = tutorialPhase.staticEnemies;

    public Dialogue dialogue;
    private Queue<string> sentences;

    public GameObject TutorialEnemy2;

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
}