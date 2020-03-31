using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsRadarScript : MonoBehaviour
{
    private GameObject selectedItem;
    public GameObject ItemSprite;
    public Transform playerBack;
    public ConsoleManager ConsoleManager;
    private GameObject pickedItem;

    // Update is called once per frame
    void Update()
    {
        if (pickedItem != null)
        {
            pickedItem.transform.position = playerBack.transform.position;
            pickedItem.transform.rotation = playerBack.transform.rotation;
        }

        if (InputManager.Instance.interact)
        {
            if (pickedItem == null)
            {
                if (selectedItem != null)
                {
                    selectedItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    selectedItem.gameObject.layer = 9;
                    pickedItem = selectedItem;
                }
            }
            else
            {
                pickedItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                pickedItem.gameObject.layer = 0;
                pickedItem = null;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            if (pickedItem == null)
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

                    GetComponentInParent<PlayerController>().canMove = false;
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