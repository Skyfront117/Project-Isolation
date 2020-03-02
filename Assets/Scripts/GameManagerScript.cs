using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject MainCamera;

    public float speed = 5.0f;

    float delta = 0.00f;

    public Vector3 mouse;
    public Vector2 position = new Vector2(0,0);
    public Vector3 cameraPosition = new Vector3(0, 0, -10);

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;

        delta = Time.deltaTime;
        bool angleChange = false;
        Vector3 newAngle = new Vector3(0, 0, 0);
        if (InputManager.Instance.moveUp)
        {
            angleChange = true;
            newAngle.z = 90;
            position.y += speed * delta;
        }
        if (InputManager.Instance.moveDown)
        {
            angleChange = true;
            newAngle.z = 180;
            position.x -= speed * delta;
        }
        if (InputManager.Instance.moveLeft)
        {
            angleChange = true;
            newAngle.z = -90;
            position.y -= speed * delta;
        }
        if (InputManager.Instance.moveRight)
        {
            angleChange = true;
            newAngle.z = 0;
            position.x += speed * delta;
        }
        player.transform.position = position;
        cameraPosition.x = position.x;
        cameraPosition.y = position.y;
        MainCamera.transform.position = cameraPosition;

        //player.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
        if (angleChange)
        {
            player.transform.rotation = Quaternion.Euler(newAngle);
        }

        
    }
}