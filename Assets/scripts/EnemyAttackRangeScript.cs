﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRangeScript : MonoBehaviour
{
    public EnemiesMovement ParentScript;
    public GameObject Player;
    playerController playerController;
    void Start()
    {
        ParentScript = this.gameObject.GetComponentInParent<EnemiesMovement>();
        playerController = Player.GetComponent<playerController>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !ParentScript.stunned)
        {
            if (!ParentScript.attacking)
            {
                ParentScript.animator.SetTrigger("attacking");
                ParentScript.attacking = true;
                ParentScript.timerAttackingA = 0;
                ParentScript.timerAttackingB = 0;
            }
            else
            {
                if((ParentScript.timerAttackingB - ParentScript.timerAttackingA) > 1)
                {
                    playerController.HP--;
                }
            }
        }
    }
}
