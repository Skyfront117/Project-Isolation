using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 10;
    Vector3 mouseScreen = new Vector3(0, 0, 0);
    Vector3 mouse = new Vector3(0, 0, 0);

    private void Start()
    {
        mouseScreen = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, mouse, speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}