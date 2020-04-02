using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy2Script : MonoBehaviour
{
    private int HP = 4;
    private GameObject player;
    Rigidbody2D rb;
    private float moveSpeed = 100;

    private Vector3 target1;
    private Vector3 target2;
    public float speed;
    private bool direction = false; //false means going right, true means going left.
    Vector2 lookDir;

    private void Start()
    {
        target1.Set(-4307, 4186, -0.1f);
        target2.Set(-5040, 4186, -0.1f);

        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity.Set(moveSpeed, 0);
    }
    //transform.Rotate(new Vector3(0, -90, 0), Space.Self);

    private void Update()
    {
        lookDir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        if (!direction)
        {
            if (transform.position.x < target1.x)
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
            if (transform.position.x > target2.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, target2, moveSpeed * Time.deltaTime);
            }
            else
            {
                direction = false;
            }
        }
    }

    //private void FixedUpdate()
    //{
    //    //timer += Time.fixedDeltaTime;
    //    //rb.velocity.Set(rb.velocity.x * Time.fixedDeltaTime, 0);
    //    //if (timer > 3)
    //    //{
    //    //    rb.velocity.Set(-rb.velocity.x * Time.fixedDeltaTime, 0);
    //    //    timer = 0;
    //    //}
    //}

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