using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject MainCamera;

    public float speed = 0.0f;

    float delta = 0.00f;

    public Vector2 position = new Vector2(0, 0);
    public Vector3 cameraPosition = new Vector3(0, 0, -10);

    void Update()
    {

    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(x, y);
        Rigidbody2D rigidBody = Player.GetComponent<Rigidbody2D>();
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        if (movement.x < 0 && mouse.x > rigidBody.position.x || movement.x > 0 && mouse.x < rigidBody.position.x || movement.y < 0 && mouse.y > rigidBody.position.y || movement.y > 0 && mouse.y < rigidBody.position.y)
        {
            speed = 8.0f;
        }
        else
        {
            speed = 16.0f;
        }
        rigidBody.velocity = (movement * speed);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);

        if (Input.GetMouseButton(0))
        {

        }
    }
}
