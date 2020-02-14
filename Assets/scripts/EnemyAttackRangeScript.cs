using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRangeScript : MonoBehaviour
{
    public EnemiesMovement Parent;
    void Start()
    {
        //Parent = this.Parent.gameObject.GetComponent<EnemiesMovement>();
        Parent = this.gameObject.GetComponentInParent<EnemiesMovement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !Parent.stunned && !Parent.attacking)
        {
            Parent.attacking = true;
            Parent.timerAttackingA = 0;
            Parent.timerAttackingB = 0;
        }
    }
}
