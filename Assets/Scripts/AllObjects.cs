using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjects : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        GetComponent<Renderer>().sortingOrder = 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Blood")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), collision.collider);
        }
    }
}
