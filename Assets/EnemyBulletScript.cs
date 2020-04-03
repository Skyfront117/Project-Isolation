using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 2.0f);
    }
}