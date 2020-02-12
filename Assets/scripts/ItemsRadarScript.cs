using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsRadarScript : MonoBehaviour
{
    public GameObject selectedItem;
    public bool picked = false;
    public Transform playerBack;
    private playerController playerControl;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (picked)
        {
            selectedItem.transform.position = playerBack.transform.position;
            selectedItem.transform.rotation = playerBack.transform.rotation;
        }

        if (Input.GetKeyDown(KeyCode.E))
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

        if (!picked)
        {
            if (collision.gameObject.tag == "Item")
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == selectedItem)
        {
            selectedItem = null;
        }
    }
}
