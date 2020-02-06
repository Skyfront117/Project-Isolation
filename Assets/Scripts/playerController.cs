using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject bulletSpawner;

    public GameObject bullet;


    public float fireRate = 0.3f;
    float timeA = 0;
    float timeB = 0;
    float bulletThrust = 50.0f;

    public float speed = 8.0f;
    public Vector2 position = new Vector2(0, 0);
    public Vector3 cameraPosition = new Vector3(0, 0, -10);

    private Vector3 mouse = new Vector3(0, 0, 0);

    private void Update()
    {
        timeB += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if ((timeB - timeA) > fireRate)
            {
                Vector2 spawn = new Vector2(bulletSpawner.transform.position.x + 0.04f, bulletSpawner.transform.position.y);
                GameObject temporalBullet = Instantiate(bullet, spawn, transform.rotation);
                temporalBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletThrust, ForceMode2D.Impulse);

                timeA = timeB;
            }
        }
    }

    void FixedUpdate()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.W))
        {
            position.y += speed * Time.fixedDeltaTime;

        }
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.y -= speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.fixedDeltaTime;
        }
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);

        transform.position = position;
        cameraPosition.x = position.x;
        cameraPosition.y = position.y;
        mainCamera.transform.position = cameraPosition;
    }
}