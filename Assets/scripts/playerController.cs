using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject bulletSpawner;
    public AudioSource audioSource;
    public Animator animator;
    Rigidbody2D rigidBody;
    public GameObject bullet;
    Vector3 originalCameraPosition;

    private float fireRate = 0.3f;
    float timeA = 0;
    float timeB = 0;
    float bulletThrust = 800;

    float speed = 90.0f;
    private Vector2 position = new Vector2(0, 0);
    private Vector3 cameraPosition = new Vector3(0, 0, -10);

    public int HP;

    private Vector3 mouse = new Vector3(0, 0, 0);

    private void Start()
    {
        animator.GetBool("moving");
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
        HP = 4;
    }

    private void Update()
    {
        timeB += Time.deltaTime;
        if (HP > 0)
        {
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
    }

    void FixedUpdate()
    {
        if (HP > 0)
        {
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                animator.SetBool("moving", false);
            }

            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetKey(KeyCode.W))
            {
                position.y += speed * Time.fixedDeltaTime;
                animator.SetBool("moving", true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                position.x -= speed * Time.fixedDeltaTime;
                animator.SetBool("moving", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                position.y -= speed * Time.fixedDeltaTime;
                animator.SetBool("moving", true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                position.x += speed * Time.fixedDeltaTime;
                animator.SetBool("moving", true);
            }
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);

            transform.position = position;
        }
        cameraPosition.x = position.x;
        cameraPosition.y = position.y;
        mainCamera.transform.position = cameraPosition;
    }
}