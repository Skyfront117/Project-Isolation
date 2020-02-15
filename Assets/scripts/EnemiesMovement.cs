using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    public Transform player;
    public Animator animator;


    private float moveSpeed = 50.0f;
    private const int startHP = 4;
    public int actualHP = startHP;
    public bool stunned = false;
    public bool attacking = false;

    float timerStunnedA = 0;
    float timerStunnedB = 0;
    public float timerAttackingA = 0;
    public float timerAttackingB = 0;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timerStunnedB += Time.deltaTime;
        timerAttackingB += Time.deltaTime;
        if(!stunned)
        {
            if (attacking)
            {
                transform.LookAt(player.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                // Animación de atacar.

                if ((timerAttackingB - timerAttackingA) > 1.02f)
                {
                    attacking = false;
                }
            }
            else
            {
                transform.LookAt(player.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                if (Vector3.Distance(transform.position, player.position) > 1.215f)
                {
                    transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
                }
            }
        }
        else if(stunned)
        {
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;

            if ((timerStunnedB - timerStunnedA) > 4)
            {
                stunned = false;
                actualHP = startHP;
                rb2D.constraints = RigidbodyConstraints2D.None;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!stunned && collision.gameObject.tag == "Bullet")
        {
            if (collision.gameObject.tag == "Bullet")
            {
                actualHP--;
                if (actualHP < 1)
                {
                    stunned = true;
                    attacking = false;
                    timerStunnedA = 0;
                    timerStunnedB = 0;
                }
            }
        }
    }

}