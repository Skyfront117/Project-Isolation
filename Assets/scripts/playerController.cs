using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject bulletSpawner;
    public Animator animator;
    Rigidbody2D rb2D;
    public GameObject bullet;

    private readonly float fireRate = 0.2f;
    private float timeA = 0;
    private float timeB = 0;
    private readonly float bulletThrust = 1500;

    private readonly float speed = 90000.0f;
    private Vector2 velocityVector = new Vector2(0, 0);
    private Vector3 cameraPosition = new Vector3(0, 0, -10);

    public int HP;

    private Vector3 mouse = new Vector3(0, 0, 0);

    public bool canMove = true;
    public Canvas menuCanvas;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        HP = 10;
    }

    private void Update()
    {
        timeB += Time.deltaTime;
        if (HP > 0)
        {
            if (InputManager.Instance.shooting && canMove)
            {
                if ((timeB - timeA) > fireRate)
                {
                    GameObject temporalBullet = Instantiate(bullet, bulletSpawner.transform.position, transform.rotation);
                    temporalBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletThrust, ForceMode2D.Impulse);
                    timeA = timeB;
                    SoundManager.Instance.PlayShot();
                }
            }
        }
        else
        {
            SceneManager.LoadScene("Death");
        }
        cameraPosition.x = transform.position.x;
        cameraPosition.y = transform.position.y;
        mainCamera.transform.position = cameraPosition;
    }

    void FixedUpdate()
    {
        velocityVector.Set(0, 0);
        animator.SetBool("moving", false);
        if (HP > 0)
        {
            if (canMove)
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

                if (InputManager.Instance.menu)
                {
                    //----> pausa el juego
                    menuCanvas.enabled = true;
                }
            }
            else
            {
                rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            HP--;
            if (HP < 1)
            {
                SceneManager.LoadScene("Death");
            }
        }
    }

}