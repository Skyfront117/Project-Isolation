﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRangeScript : MonoBehaviour
{
    public xd ParentScript;
    public GameObject Player;
    PlayerController PlayerController;
    void Start()
    {
        Player = GameObject.Find("Player");
        ParentScript = this.gameObject.GetComponentInParent<xd>();
        PlayerController = Player.GetComponent<PlayerController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !ParentScript.stunned)
        {
            if (!ParentScript.attacking)
            {
                ParentScript.animatorTentacles.SetTrigger("attacking");
                ParentScript.attacking = true;
                ParentScript.timerAttackingA = 0;
                ParentScript.timerAttackingB = 0;
            }
            else
            {
                if((ParentScript.timerAttackingB - ParentScript.timerAttackingA) > 0.25)
                {
                    PlayerController.HP--;
                }
            }
        }
    }
}
