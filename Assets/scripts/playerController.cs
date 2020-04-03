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
    public Canvas optionsCanvas;

    private readonly float fireRate = 0.3f;
    private float timeA = 0;
    private float timeB = 0;
    private readonly float bulletThrust = 800;

    private readonly float speed = 90000.0f;
    private Vector2 velocityVector = new Vector2(0, 0);
    private Vector3 cameraPosition = new Vector3(0, 0, -10);

    public int HP;

    private Vector3 mouse = new Vector3(0, 0, 0);

    public bool connectedToConsole = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        HP = 50;
    }

    private void Update()
    {
        timeB += Time.deltaTime;
        if (HP > 0)
        {
            if (InputManager.Instance.shooting && !connectedToConsole)
            {
                if ((timeB - timeA) > fireRate)
                {
                    GameObject temporalBullet = Instantiate(bullet, bulletSpawner.transform.position, transform.rotation);
                    temporalBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletThrust, ForceMode2D.Impulse);
                    timeA = timeB;
                }
            }
        }
        else
        {
            SceneManager.LoadScene("Death");
        }
    }

    void FixedUpdate()
    {
        velocityVector.Set(0, 0);
        //rb2D.velocity = Vector2.zero;
        //animator.SetBool("moving", false);
        animator.SetBool("movingForward", false);
        animator.SetBool("movingBack", false);
        animator.SetBool("movingRight", false);
        animator.SetBool("movingLeft", false);
        animator.SetBool("movingNorthWest", false);
        animator.SetBool("movingNorthEast", false);
        animator.SetBool("movingSouthWest", false);
        animator.SetBool("movingSouthEast", false);
        if (HP > 0)
        {
            if (!connectedToConsole)
            {
                rb2D.constraints = RigidbodyConstraints2D.None;

                mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (InputManager.Instance.moveUp)
                {
                    velocityVector.y += speed * Time.fixedDeltaTime;                    
                }
                if (InputManager.Instance.moveLeft)
                {
                    velocityVector.x -= speed * Time.fixedDeltaTime;
                    //animator.SetBool("moving", true);
                }
                if (InputManager.Instance.moveDown)
                {
                    velocityVector.y -= speed * Time.fixedDeltaTime;
                    //animator.SetBool("moving", true);
                }
                if (InputManager.Instance.moveRight)
                {
                    velocityVector.x += speed * Time.fixedDeltaTime;
                    //animator.SetBool("moving", true);
                }
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
                if (transform.localRotation == Quaternion.Euler(0, 0, 0))
                {
                    animator.SetBool("movingForward", true);
                } else if(transform.localRotation == Quaternion.Euler(0, 0, 90))
                {
                    animator.SetBool("movingLeft", true);
                } else if(transform.localRotation == Quaternion.Euler(0, 0, 180))
                {
                    animator.SetBool("movingBack", true);
                } else if(transform.localRotation == Quaternion.Euler(0, 0, 270))
                {
                    animator.SetBool("movingRight", true);
                } else if(transform.localRotation == Quaternion.Euler(0, 0, 45))
                {
                    animator.SetBool("movingNorthWest", true);
                } else if(transform.localRotation == Quaternion.Euler(0, 0, 135))
                {
                    animator.SetBool("movingSouthWest", true);
                } else if(transform.localRotation == Quaternion.Euler(0, 0, 225))
                {
                    animator.SetBool("movingSouthEast", true);
                } else if(transform.localRotation == Quaternion.Euler(0, 0, 315))
                {
                    animator.SetBool("movingNorthEast", true);
                }

                if (InputManager.Instance.menu && !connectedToConsole)
                {
                    optionsCanvas.enabled = true;
                }

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