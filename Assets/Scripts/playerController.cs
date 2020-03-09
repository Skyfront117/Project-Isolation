using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject bulletSpawner;
    public AudioSource audioSource;
    public Animator animator;
    Rigidbody2D rb2D;
    public GameObject bullet;

    private ConsoleManager ConsoleManager;

    private readonly float fireRate = 0.3f;
    private float timeA = 0;
    private float timeB = 0;
    private readonly float bulletThrust = 800;

    private readonly float speed = 9000.0f;
    private Vector2 velocityVector = new Vector2(0, 0);
    private Vector3 cameraPosition = new Vector3(0, 0, -10);

    private Vector3 mouse = new Vector3(0, 0, 0);

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();

        ConsoleManager = FindObjectOfType<ConsoleManager>();
    }

    private void Update()
    {
        timeB += Time.deltaTime;
        if (GameManager.Instance.playerHP > 0)
        {
            if (InputManager.Instance.shooting && !ConsoleManager.playerConnected)
            {
                if ((timeB - timeA) > fireRate)
                {
                    GameObject temporalBullet = Instantiate(bullet, bulletSpawner.transform.position, transform.rotation);
                    temporalBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletThrust, ForceMode2D.Impulse);
                    timeA = timeB;
                    audioSource.Play(0);
                    GameManager.Instance.score--;
                }
            }
        }
    }

    void FixedUpdate()
    {
        velocityVector.Set(0, 0);
        //rb2D.velocity = Vector2.zero;
        animator.SetBool("moving", false);
        if (GameManager.Instance.playerHP > 0)
        {
            if (!ConsoleManager.playerConnected)
            {
                rb2D.constraints = RigidbodyConstraints2D.None;

                mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (InputManager.Instance.moveUp)
                {
                    velocityVector.y += speed * Time.fixedDeltaTime;
                    animator.SetBool("moving", true);
                }
                if (InputManager.Instance.moveLeft)
                {
                    velocityVector.x -= speed * Time.fixedDeltaTime;
                    animator.SetBool("moving", true);
                }
                if (InputManager.Instance.moveDown)
                {
                    velocityVector.y -= speed * Time.fixedDeltaTime;
                    animator.SetBool("moving", true);
                }
                if (InputManager.Instance.moveRight)
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
                rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            }            
        }
    }
}