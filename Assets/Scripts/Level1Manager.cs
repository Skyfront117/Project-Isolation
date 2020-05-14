using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    enum Fases { FIRST, DOOR_CLOSES, CIRCLE_APPEARS }


    private GameObject Player;
    private GameObject openedDoor;
    public GameObject closedDoor;
    public GameObject circle;

    private GameObject[] aEnemies;

    private Fases actualFase;

    private void Start()
    {
        Player = GameObject.Find("Player");
        aEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in aEnemies)
        {
            enemy.SetActive(false);
        }

        openedDoor = GameObject.Find("OpenedDoorLevel1");
    }

    private void Update()
    {
        switch (actualFase)
        {
            case Fases.FIRST:
                if (Player.transform.position.x > 6140)
                {
                    openedDoor.SetActive(false);
                    Instantiate<GameObject>(closedDoor);
                    actualFase++;
                }
                break;
            case Fases.DOOR_CLOSES:
                if (Player.transform.position.x > 6200)
                {
                    Instantiate<GameObject>(circle);
                    foreach (GameObject enemy in aEnemies)
                    {
                        enemy.SetActive(true);
                    }
                    actualFase++;
                }
                break;
            case Fases.CIRCLE_APPEARS:
                break;
            default:
                break;
        }
    }


}
