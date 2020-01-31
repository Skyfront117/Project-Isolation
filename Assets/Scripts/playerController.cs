using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject MainCamera;

    private float speed = 15.0f;

    float delta = 0.00f;

    public Vector2 position = new Vector2(0, 0);
    public Vector3 cameraPosition = new Vector3(0, 0, -10);

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(x, y);
        Rigidbody2D rigidBody = Player.GetComponent<Rigidbody2D>();
        rigidBody.velocity = (movement * speed);
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
    }
}
