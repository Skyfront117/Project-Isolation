using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy2Script : MonoBehaviour
{
    private int HP = 4;
    private GameObject player;

    private readonly float moveSpeed = 100;
    private Rigidbody2D rb;
    private Vector3 target1;
    private Vector3 target2;
    private bool direction = false; //false means going right, true means going left.


    private Animator animator;
    private int dieParamID;
    private bool dying = false;
    private float dyingTimer = 0;

    private void Start()
    {
        target1.Set(-494.8f, 535.3f, -0.1f);
        target2.Set(-394.8f, 535.3f, -0.1f);

        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity.Set(moveSpeed, 0);

        animator = GetComponent<Animator>();
        dieParamID = Animator.StringToHash("Die");
    }

    private void Update()
    {
        if (dying)
        {
            dyingTimer += Time.deltaTime;
            if (dyingTimer > 0.25f)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (!direction)
            {
                if (transform.position.x > target1.x)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target1, moveSpeed * Time.deltaTime);
                }
                else
                {
                    direction = true;
                }
            }
            else
            {
                if (transform.position.x < target2.x)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target2, moveSpeed * Time.deltaTime);
                }
                else
                {
                    direction = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HP--;
            if (HP < 1)
            {
                TutorialManager.Instance.enemiesCount--;
                animator.SetTrigger(dieParamID);
                dying = true;
            }
        }
    }
}