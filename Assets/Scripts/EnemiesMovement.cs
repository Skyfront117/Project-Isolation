using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    Transform target;
    public float moveSpeed = 5.0f;
    public int life = 4;
    public float actualTime = 4.0f;
    public bool stunned = false;
    private float delta = 0.0f;
    private float timer = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        delta = Time.deltaTime;
        if (stunned == false)
        {
            transform.LookAt(target.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            if (Vector3.Distance(transform.position, target.position) > 1.215f)
            {
                transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
            }
        }
        else
        {
            if (actualTime > 0)
            {
                actualTime -= delta;
            }
            else
            {
                stunned = false;
                life = 4;
                actualTime = timer;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (life > 1)
            {
                life--;
            }
            else if (life == 1)
            {
                stunned = true;
            }
        }
    }
}
