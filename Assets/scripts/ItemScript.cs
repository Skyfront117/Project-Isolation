using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public Transform player;
    private bool picked = false;

    public Text pickupText;
    private float pickRange = 15;
    private float realDistanceX = 0;
    private float realDistanceY = 0;

    void Update()
    {
        if (picked == true)
        {
            transform.position = GameObject.Find("PlayerBack").transform.position;
            transform.rotation = player.transform.rotation;
        }





        if (!picked)
        {

            if ((transform.position.x - player.transform.position.x) < 0)
            {
                realDistanceX = player.transform.position.x - transform.position.x;
            }
            else
            {
                realDistanceX = transform.position.x - player.transform.position.x;
            }

            if ((transform.position.y - player.transform.position.y) < 0)
            {
                realDistanceY = player.transform.position.y - transform.position.y;
            }
            else
            {
                realDistanceY = transform.position.y - player.transform.position.y;
            }
            if (realDistanceX < pickRange && realDistanceY < pickRange)
            {
                pickupText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    picked = true;
                }
            }
        }
        else
        {
            pickupText.gameObject.SetActive(false);
            picked = false;
        }



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickRange);
    }
}
