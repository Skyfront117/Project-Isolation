using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsRadarScript : MonoBehaviour
{
    public GameObject selectedItem;
    public bool picked = false;
    public Transform playerBack;

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
                }
            }
            else
            {
                picked = false;
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
