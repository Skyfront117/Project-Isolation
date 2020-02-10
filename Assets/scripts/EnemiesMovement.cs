using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    Transform target;
    private float moveSpeed = 50.0f;
    private const int startHP = 4;
    private int actualHP = startHP;
    private bool stunned;

    float timerA = 0;
    float timerB = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timerB += Time.deltaTime;
        if (actualHP > 0)
        {
            transform.LookAt(target.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            if (Vector3.Distance(transform.position, target.position) > 1.215f)
            {
                transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
            }
        }
        if (stunned)
        {
            if ((timerB - timerA) > 4)
            {
                stunned = false;
                actualHP = startHP;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!stunned)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                actualHP--;
                if (actualHP < 1)
                {
                    stunned = true;
                    timerA = 0;
                    timerB = 0;
                }
            }
        }
        
    }
}