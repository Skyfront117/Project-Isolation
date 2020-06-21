using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoorTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TutorialManager.Instance.DoorTutorial();
        }
    }
}