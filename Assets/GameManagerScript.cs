using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject player;

    public float speed = 5.0f;

    float delta = 0.00f;

    public Vector3 mouse;
    public Vector2 position = new Vector2(0,0);

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;

        delta = Time.deltaTime;
        bool angleChange = false;
        Vector3 newAngle = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            angleChange = true;
            newAngle.z = 90;
            position.y += speed * delta;
        }
        if (Input.GetKey(KeyCode.A))
        {
            angleChange = true;
            newAngle.z = 180;
            position.x -= speed * delta;
        }
        if (Input.GetKey(KeyCode.S))
        {
            angleChange = true;
            newAngle.z = -90;
            position.y -= speed * delta;
        }
        if (Input.GetKey(KeyCode.D))
        {
            angleChange = true;
            newAngle.z = 0;
            position.x += speed * delta;
        }
        player.transform.position = position;

        if (angleChange)
        {
            player.transform.rotation = Quaternion.Euler(newAngle);
        }
    }
}