using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public Transform player;
    public bool picked = false;

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

        if(Input.GetKeyDown(KeyCode.E))
        {
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
                    picked = true;
                } 
            }
            else
            {
                picked = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickRange);
    }
}
