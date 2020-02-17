using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject bulletSpawner;
    public AudioSource audioSource;
    public Animator animator;
    Rigidbody2D rb2D;
    public GameObject bullet;

    private readonly float fireRate = 0.3f;
    private float timeA = 0;
    private float timeB = 0;
    private readonly float bulletThrust = 800;

    private readonly float speed = 9000.0f;
    private Vector2 velocityVector = new Vector2(0, 0);
    private Vector3 cameraPosition = new Vector3(0, 0, -10);

    public int HP;

    private Vector3 mouse = new Vector3(0, 0, 0);

    private void Start()
    {
        animator.GetBool("moving");
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
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
        velocityVector.Set(0, 0);
        animator.SetBool("moving", false);
        if (HP > 0)
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetKey(KeyCode.W))
            {
                velocityVector.y += speed * Time.fixedDeltaTime;
                animator.SetBool("moving", true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                velocityVector.x -= speed * Time.fixedDeltaTime;
                animator.SetBool("moving", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                velocityVector.y -= speed * Time.fixedDeltaTime;
                animator.SetBool("moving", true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                velocityVector.x += speed * Time.fixedDeltaTime;
                animator.SetBool("moving", true);
            }
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);

            rb2D.velocity = velocityVector;
            cameraPosition.x = transform.position.x;
            cameraPosition.y = transform.position.y;
            mainCamera.transform.position = cameraPosition;
        }
        else
        {
            // Die
        }
    }
}