using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy2Script : MonoBehaviour
{
    private int HP = 4;
    private GameObject player;
    Rigidbody2D rb;
    float timer = 0;
    private float moveSpeed = 50;

    private void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity.Set(moveSpeed, 0);
    }
    //transform.Rotate(new Vector3(0, -90, 0), Space.Self);

    private void Update()
    {
        Vector2 lookDir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer > 3)
        {
            rb.velocity.Set(-rb.velocity.x, 0);
            timer = 0;
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
                Destroy(this.gameObject);
            }
        }
    }
}