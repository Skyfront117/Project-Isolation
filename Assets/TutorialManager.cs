using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }
    public int enemiesCount = 4;
    private enum tutorialPhase { staticEnemies, movingEnemies, normalEnemies, levelLearning};
    private tutorialPhase actualPhase = tutorialPhase.staticEnemies;

    public GameObject TutorialEnemy2;

    // Update is called once per frame
    void Update()
    {
        switch (actualPhase)
        {
            case tutorialPhase.staticEnemies:
                if (enemiesCount < 1)
                {
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
