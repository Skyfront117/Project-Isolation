using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy1Script : MonoBehaviour
{
    private int HP = 4;
    private GameObject player;
    Rigidbody2D rb;

    public Animator animator;
    public int dieParamID;
    bool dying = false;
    float dyingTimer = 0;

    private void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
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

        Vector2 lookDir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle; 
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

