using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsRadarScript : MonoBehaviour
{
    private GameObject selectedItem;
    public bool picked = false;
    public Transform playerBack;
    public ConsoleManager ConsoleManager;

    // Update is called once per frame
    void Update()
    {
        if (picked)
        {
            selectedItem.transform.position = playerBack.transform.position;
            selectedItem.transform.rotation = playerBack.transform.rotation;
        }

        if (InputManager.Instance.interact)
        {
            if (!picked)
            {
                if (selectedItem != null)
                {
                    picked = true;
                    playerControl.playerItem = true;
                }
            }
            else
            {
                picked = false;
                playerControl.playerItem = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            if (!picked)
            {
                if (selectedItem == null)
                {
                    selectedItem = collision.gameObject;
                    return;
                }
                if (selectedItem != collision.gameObject)
                {
                    if (Vector2.Distance(transform.position, collision.transform.position) < Vector2.Distance(transform.position, selectedItem.transform.position))
                    {
                        selectedItem = collision.gameObject;
                    }
                }
            }
        }
        if (collision.gameObject.tag == "Door")
        {
            if (ConsoleManager == null)
            {
                if (InputManager.Instance.consoleConect)
                {
                    collision.GetComponent<DoorScript>().ActivateConsole();
                    ConsoleManager = collision.GetComponentInChildren<ConsoleManager>();

                    GetComponentInParent<PlayerController>().connectedToConsole = true;
                    ConsoleManager.playerConnected = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == selectedItem)
        {
            selectedItem = null;
        }
    }
}