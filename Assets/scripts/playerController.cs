using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject bulletSpawner;
    public AudioSource audioSource;

    public GameObject bullet;
    Vector3 originalCameraPosition;

    public float fireRate = 0.6f;
    float timeA = 0;
    float timeB = 0;
    float bulletThrust = 800;
    float shakeAmt = 0;

    float speed = 90.0f;
    public Vector2 position = new Vector2(0, 0);
    public Vector3 cameraPosition = new Vector3(0, 0, -10);

    private Vector3 mouse = new Vector3(0, 0, 0);
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        timeB += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if ((timeB - timeA) > fireRate)
            {
                GameObject temporalBullet = Instantiate(bullet, bulletSpawner.transform.position, transform.rotation);
                temporalBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletThrust, ForceMode2D.Impulse);
                timeA = timeB;
                audioSource.Play(0);
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