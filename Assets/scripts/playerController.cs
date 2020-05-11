using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{


    enum directions
    {
        North, South, East, West, NorthEast, NorthWest, SouthEast, SouthWest
    }




    GameObject mainCamera;
    GameObject bulletSpawner;
    Animator animator;
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

    Transform north;
    Transform northEast;
    Transform east;
    Transform southEast;
    Transform south;
    Transform southWest;
    Transform west;
    Transform northWest;
    Transform lookAt;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.Find("Main Camera");
        bulletSpawner = GameObject.Find("bulletSpawner");
        animator = GetComponent<Animator>();
        HP = 10;
        
        north = GameObject.Find("North").transform;
        northEast = GameObject.Find("NorthEast").transform;
        east = GameObject.Find("East").transform;
        southEast = GameObject.Find("SouthEast").transform;
        south = GameObject.Find("South").transform;
        southWest = GameObject.Find("SouthWest").transform;
        west = GameObject.Find("West").transform;
        northWest = GameObject.Find("NorthWest").transform;
        lookAt = GameObject.Find("LookAt").transform;
    }

    private void Update()
    {
        timeB += Time.deltaTime;
        if (HP > 0)
        {
            AnimationSet();
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


    private void AnimationSet()
    {
        //setear todos los bools de animaciones a cero
        directions lookDirection = directions.North;
        directions moveDirection = directions.North;





        float shortestDistance = 99999999;

        if (Vector3.Distance(lookAt.position, north.position) < shortestDistance)
        {
            shortestDistance = Vector3.Distance(lookAt.position, north.position);
            lookDirection = directions.North;
        }
        if (Vector3.Distance(lookAt.position, northEast.position) < shortestDistance)
        {
            shortestDistance = Vector3.Distance(lookAt.position, northEast.position);
            lookDirection = directions.NorthEast;
        }
        if (Vector3.Distance(lookAt.position, east.position) < shortestDistance)
        {
            shortestDistance = Vector3.Distance(lookAt.position, east.position);
            lookDirection = directions.East;
        }
        if (Vector3.Distance(lookAt.position, southEast.position) < shortestDistance)
        {
            shortestDistance = Vector3.Distance(lookAt.position, southEast.position);
            lookDirection = directions.SouthEast;
        }
        if (Vector3.Distance(lookAt.position, south.position) < shortestDistance)
        {
            shortestDistance = Vector3.Distance(lookAt.position, south.position);
            lookDirection = directions.South;
        }
        if (Vector3.Distance(lookAt.position, southWest.position) < shortestDistance)
        {
            shortestDistance = Vector3.Distance(lookAt.position, southWest.position);
            lookDirection = directions.SouthWest;
        }
        if (Vector3.Distance(lookAt.position, west.position) < shortestDistance)
        {
            shortestDistance = Vector3.Distance(lookAt.position, west.position);
            lookDirection = directions.West;
        }
        if (Vector3.Distance(lookAt.position, northWest.position) < shortestDistance)
        {
            shortestDistance = Vector3.Distance(lookAt.position, northWest.position);
            lookDirection = directions.NorthWest;
        }

        switch (lookDirection)
        {
            case directions.North:
                //Activar bool que toque
                break;
            case directions.South:
                //Activar bool que toque
                break;
            case directions.East:
                //Activar bool que toque
                break;
            case directions.West:
                //Activar bool que toque
                break;
            case directions.NorthEast:
                //Activar bool que toque
                break;
            case directions.NorthWest:
                //Activar bool que toque
                break;
            case directions.SouthEast:
                //Activar bool que toque
                break;
            case directions.SouthWest:
                //Activar bool que toque
                break;
            default:
                break;
        }
    }

}