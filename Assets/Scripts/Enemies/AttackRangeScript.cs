using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeScript : MonoBehaviour
{
    public EnemyMovement ParentScript;
    public GameObject Player;

    public float ATtimer = 0;
    public float ATmax = 1.0f;

    void Start()
    {
        Player = GameObject.Find("Player");
        ParentScript = gameObject.GetComponentInParent<EnemyMovement>();
    }

    void Update()
    {
        if (!ParentScript.attacking)
        {
            ATtimer += Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !ParentScript.stunned)
        {
            if (ATtimer >= ATmax)
            {
                if (!ParentScript.attacking)
                {
                    ParentScript.attacking = true;
                    ATtimer = 0;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ParentScript.attacking = false;
    }
}
