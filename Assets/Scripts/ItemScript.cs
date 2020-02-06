using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public Transform player;
    private bool picked = false;

    public Text pickupText;
    private float pickRange = 2;
    private float realDistanceX = 0;
    private float realDistanceY = 0;

    void Update()
    {
        if (picked)
        {
            transform.position = GameObject.Find("PlayerBack").transform.position;
            transform.rotation = player.transform.rotation;

            if (Input.GetKeyDown(KeyCode.E))
            {
                picked = false;
            }
        }
        if (!picked)
        {
            if (Vector3.Distance(transform.position, player.position) > pickRange)
            {
                pickupText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    picked = true;
                    pickupText.gameObject.SetActive(false);
                }
            }
            else
            {
                pickupText.gameObject.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickRange);
    }
}
