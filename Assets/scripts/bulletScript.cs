using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{ 
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 4.0f);
    }
}