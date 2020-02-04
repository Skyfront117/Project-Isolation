using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject MainCamera;

    public float speed = 8.0f;

    float delta = 0.00f;

    public Vector2 position = new Vector2(0, 0);
    public Vector3 cameraPosition = new Vector3(0, 0, -10);
    Vector3 mouseScreen = new Vector3(0, 0, 0);
    Vector3 mouse = new Vector3(0, 0, 0);

    void FixedUpdate()
    {
        delta = Time.deltaTime;
        Rigidbody2D rigidBody = Player.GetComponent<Rigidbody2D>();
        mouseScreen = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        if (Input.GetKey(KeyCode.W))
        {
            position.y += speed * delta;
        }
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed * delta;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.y -= speed * delta;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * delta;
        }
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);

        Player.transform.position = position;
        cameraPosition.x = position.x;
        cameraPosition.y = position.y;
        MainCamera.transform.position = cameraPosition;

        //if (Input.GetMouseButton(0))
        //{

        //}
    }
}