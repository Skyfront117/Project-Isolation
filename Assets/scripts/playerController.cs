using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform pfFieldOfView;
    private FOVScript fieldOfView;
    enum directions
    {
        North, South, East, West, NorthEast, NorthWest, SouthEast, SouthWest, NONE
    }

    [Range(0, 8)]
    public float invisiblePoints = 8;

    public Image Athenaphoto;

    GameObject mainCamera;
    GameObject bulletSpawner;
    Animator animator;
    Rigidbody2D rb2D;
    public GameObject bullet;

    private readonly float fireRate = 0.2f;
    private float timeA = 0;
    private float timeB = 0;
    private float beatTimeMax = 0.5f;
    private float beatTime = 0;
    private readonly float bulletThrust = 1000;
    private float AstarUpdateTime = 0;
    private float AstarUpdateMax = 10.0f;

    private readonly float speed = 9000.0f;
    private Vector2 velocityVector = new Vector2(0, 0);
    private Vector3 cameraPosition = new Vector3(0, 0, -10);

    public int HP;

    public Sprite Athena1;
    public Sprite Athena2;

    private Vector3 mouse = new Vector3(0, 0, 0);

    public bool moving = false;
    public bool canMove = true;
    public bool isHacking = false;
    public Canvas menuCanvas;

    private float nextStep;
    private float stepsCounter;

    Transform north;
    Transform northEast;
    Transform east;
    Transform southEast;
    Transform south;
    Transform southWest;
    Transform west;
    Transform northWest;
    Transform lookAt;

    public bool isInvisible = false;

    private void Start()
    {
        nextStep = 0.5f;
        stepsCounter = 0.5f;
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
        fieldOfView = Instantiate(pfFieldOfView, null).GetComponent<FOVScript>();
    }

    private void Update()
    {
        fieldOfView.setPlayer(1);
        AstarUpdateTime += Time.deltaTime;
        if (AstarUpdateTime >= AstarUpdateMax)
        {
            AstarPath.active.UpdateGraphs(new Bounds(new Vector3(0, 0, 0), new Vector3(200, 200)));
            AstarUpdateTime = 0;
        }
        Vector3 aimDir = mouse - bulletSpawner.transform.position;
        fieldOfView.setOrigin(bulletSpawner.transform.position);
        fieldOfView.setAimDirection(aimDir);
        timeB += Time.deltaTime;
        if (HP < 6 && HP > 3)
        {
            Athenaphoto.sprite = Athena1;
        }
        else if(HP <= 3 && HP > 0)
        {
            beatTime += Time.deltaTime;
            if (beatTime >= beatTimeMax)
            {
                SoundManager.Instance.PlayBeat();
                beatTime = 0;
            }
            Athenaphoto.sprite = Athena2;

        }
        
        if (HP > 0)
        {
            AnimationSet();
            if (InputManager.Instance.menu)
            {
                if(Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    menuCanvas.enabled = true;
                }else if(Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                    menuCanvas.enabled = true;
                }
            }
            if (InputManager.Instance.shooting && canMove)
            {
                if ((timeB - timeA) > fireRate)
                {
                    if(Time.timeScale == 1)
                    {
                        //Disparo por instancia de bala

                        GameObject temporalBullet = Instantiate(bullet, bulletSpawner.transform.position, transform.rotation);
                        temporalBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletThrust, ForceMode2D.Impulse);
                        timeA = timeB;
                        SoundManager.Instance.PlayShot();

                        //NUEVO disparo por raycast (testing raro)
                        //RaycastHit2D raycastHit2D = Physics2D.Raycast(bulletSpawner.transform.position, aimDir);
                        //if (raycastHit2D.collider != null && raycastHit2D.collider.tag == "Enemy")
                        //{
                        //    EnemyMovement enemy = raycastHit2D.collider.GetComponent<EnemyMovement>();
                        //    enemy.actualHP--;
                        //    GameObject bloodSplatter = Instantiate(enemy.blood, raycastHit2D.point, Quaternion.Inverse(raycastHit2D.transform.rotation));
                        //    Instantiate(enemy.bloodSpray, raycastHit2D.point, Quaternion.Inverse(raycastHit2D.transform.rotation));
                        //    enemy.timerMaxBlood -= 0.02f;
                        //    enemy.ATmax -= 0.05f;
                        //    SoundManager.Instance.PlayBlood();
                        //    if (!enemy.stunned)
                        //    {
                        //        if (enemy.actualHP < 1)
                        //        {
                        //            Debug.Log("Stunned");
                        //            enemy.animator.SetBool("stunned", true);
                        //            enemy.stunned = true;
                        //            enemy.speed += 200;
                        //            enemy.totalHP--;
                        //            if (enemy.totalHP == 0)
                        //            {
                        //                Instantiate(enemy.corpse, transform.position, raycastHit2D.transform.rotation);
                        //                Destroy(gameObject);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            if (!enemy.ultraAlert && !fieldOfView.target)
                        //            {
                        //                enemy.speed += 1000;
                        //                enemy.ultraAlert = true;
                        //                Vector2 lookDir = GameObject.Find("Player").transform.position - raycastHit2D.transform.position;
                        //                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
                        //                enemy.rb2d.rotation = angle - 90;
                        //            }
                        //            else if (!enemy.ultraAlert && fieldOfView.target)
                        //            {
                        //                enemy.AlertTimer = 0;
                        //            }
                        //            if (!enemy.alert && enemy.ultraAlert)
                        //            {
                        //                enemy.UltraAlertTimer = 0;
                        //            }
                        //        }
                        //    }
                        //}
                    }                    
                }
            }

            if (!isInvisible)
            {
                //Athena is visible
                if (InputManager.Instance.interactInvisible && canMove && invisiblePoints > 2)
                {
                    //Athena becomes invisible
                    isInvisible = true;
                    InputManager.Instance.interactInvisible = false;

                    Color temporalColor = this.GetComponent<SpriteRenderer>().material.color;
                    this.GetComponent<SpriteRenderer>().material.color = new Color(temporalColor.r, temporalColor.g, temporalColor.b, 0.3f);
                }
                invisiblePoints += (Time.deltaTime / 1.5f);
                if (invisiblePoints > 8)
                {
                    invisiblePoints = 8;
                }
            }
            else
            {
                //Athena is invisible
                if (InputManager.Instance.interactInvisible && canMove)
                {
                    //Athena becomes visible
                    isInvisible = false;
                    InputManager.Instance.interactInvisible = false;

                    Color temporalColor = this.GetComponent<SpriteRenderer>().material.color;
                    this.GetComponent<SpriteRenderer>().material.color = new Color(temporalColor.r, temporalColor.g, temporalColor.b, 1.0f);
                }
                invisiblePoints -= Time.deltaTime;
                if (invisiblePoints <= 0)
                {
                    isInvisible = false;
                    Color temporalColor = this.GetComponent<SpriteRenderer>().material.color;
                    this.GetComponent<SpriteRenderer>().material.color = new Color(temporalColor.r, temporalColor.g, temporalColor.b, 1.0f);
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
        stepsCounter += Time.fixedDeltaTime;
        velocityVector.Set(0, 0);
        if (HP > 0)
        {
            if (canMove)
            {
                rb2D.constraints = RigidbodyConstraints2D.None;

                mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (InputManager.Instance.moveUp)
                {
                    velocityVector.y += speed * Time.fixedDeltaTime;
                    moving = true;
                }
                if (InputManager.Instance.moveLeft)
                {
                    velocityVector.x -= speed * Time.fixedDeltaTime;
                    moving = true;
                }
                if (InputManager.Instance.moveDown)
                {
                    velocityVector.y -= speed * Time.fixedDeltaTime;
                    moving = true;
                }
                if (InputManager.Instance.moveRight)
                {
                    velocityVector.x += speed * Time.fixedDeltaTime;
                    moving = true;
                }
                if (!InputManager.Instance.moveRight && !InputManager.Instance.moveDown && !InputManager.Instance.moveUp && !InputManager.Instance.moveLeft)
                {
                    moving = false;
                    rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
                }
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);


                rb2D.velocity = velocityVector;          
            }

            if (moving && !isInvisible)
            {
                playSound();
            }
        }
    }

    private void playSound()
    {
        nextStep = 1f / (speed / 1000);
        if (nextStep < 0.22f)
        {
            nextStep = 0.22f;
        }
        if (stepsCounter >= nextStep)
        {
            stepsCounter = 0;
            SoundManager.Instance.PlaySteps();
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
        SetAnimsToFalse();

        if (isHacking)
        {
            animator.SetBool("AthenaHacking", true);
            return;
        }

        if (!canMove) { return; }

        directions lookDirection = directions.North;
        directions moveDirection = directions.North;

        if (rb2D.velocity.y > 0)
        {
            if (rb2D.velocity.x > 0)
            {
                moveDirection = directions.NorthEast;
            }
            else if (rb2D.velocity.x == 0)
            {
                moveDirection = directions.North;
            }
            else if (rb2D.velocity.x < 0)
            {
                moveDirection = directions.NorthWest;
            }
        }
        else if (rb2D.velocity.y == 0)
        {
            if (rb2D.velocity.x > 0)
            {
                moveDirection = directions.East;
            }
            else if (rb2D.velocity.x == 0)
            {
                moveDirection = directions.NONE;
            }
            else if (rb2D.velocity.x < 0)
            {
                moveDirection = directions.West;
            }
        }
        else if (rb2D.velocity.y < 0)
        {
            if (rb2D.velocity.x > 0)
            {
                moveDirection = directions.SouthEast;
            }
            else if (rb2D.velocity.x == 0)
            {
                moveDirection = directions.South;
            }
            else if (rb2D.velocity.x < 0)
            {
                moveDirection = directions.SouthWest;
            }
        }

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
                switch (moveDirection)
                {
                    case directions.North:
                        animator.SetBool("AthenaFrontRun", true);
                        break;
                    case directions.South:
                        animator.SetBool("AthenaBackRun", true);
                        break;
                    case directions.East:
                        animator.SetBool("AthenaRightRun", true);
                        break;
                    case directions.West:
                        animator.SetBool("AthenaLeftRun", true);
                        break;
                    case directions.NorthEast:
                        animator.SetBool("AthenaFrontRightRun", true);
                        break;
                    case directions.NorthWest:
                        animator.SetBool("AthenaFrontLeftRun", true);
                        break;
                    case directions.SouthEast:
                        animator.SetBool("AthenaBackRightRun", true);
                        break;
                    case directions.SouthWest:
                        animator.SetBool("AthenaBackLeftRun", true);
                        break;

                    default:
                        break;
                }
                break;
            case directions.South:
                switch (moveDirection)
                {
                    case directions.North:
                        animator.SetBool("AthenaBackRun", true);
                        break;
                    case directions.South:
                        animator.SetBool("AthenaFrontRun", true);
                        break;
                    case directions.East:
                        animator.SetBool("AthenaLeftRun", true);
                        break;
                    case directions.West:
                        animator.SetBool("AthenaRightRun", true);
                        break;
                    case directions.NorthEast:
                        animator.SetBool("AthenaBackLeftRun", true);
                        break;
                    case directions.NorthWest:
                        animator.SetBool("AthenaBackRightRun", true);
                        break;
                    case directions.SouthEast:
                        animator.SetBool("AthenaFrontLeftRun", true);
                        break;
                    case directions.SouthWest:
                        animator.SetBool("AthenaFrontRightRun", true);
                        break;

                    default:
                        break;
                }
                break;
            case directions.East:
                switch (moveDirection)
                {
                    case directions.North:
                        animator.SetBool("AthenaLeftRun", true);
                        break;
                    case directions.South:
                        animator.SetBool("AthenaRightRun", true);
                        break;
                    case directions.East:
                        animator.SetBool("AthenaFrontRun", true);
                        break;
                    case directions.West:
                        animator.SetBool("AthenaBackRun", true);
                        break;
                    case directions.NorthEast:
                        animator.SetBool("AthenaFrontLeftRun", true);
                        break;
                    case directions.NorthWest:
                        animator.SetBool("AthenaBackLeftRun", true);
                        break;
                    case directions.SouthEast:
                        animator.SetBool("AthenaFrontRightRun", true);
                        break;
                    case directions.SouthWest:
                        animator.SetBool("AthenaBackRightRun", true);
                        break;

                    default:
                        break;
                }
                break;
            case directions.West:
                switch (moveDirection)
                {
                    case directions.North:
                        animator.SetBool("AthenaRightRun", true);
                        break;
                    case directions.South:
                        animator.SetBool("AthenaLeftRun", true);
                        break;
                    case directions.East:
                        animator.SetBool("AthenaBackRun", true);
                        break;
                    case directions.West:
                        animator.SetBool("AthenaFrontRun", true);
                        break;
                    case directions.NorthEast:
                        animator.SetBool("AthenaBackRightRun", true);
                        break;
                    case directions.NorthWest:
                        animator.SetBool("AthenaFrontRightRun", true);
                        break;
                    case directions.SouthEast:
                        animator.SetBool("AthenaBackLeftRun", true);
                        break;
                    case directions.SouthWest:
                        animator.SetBool("AthenaFrontLeftRun", true);
                        break;

                    default:
                        break;
                }
                break;
            case directions.NorthEast:
                switch (moveDirection)
                {
                    case directions.North:
                        animator.SetBool("AthenaFrontLeftRun", true);
                        break;
                    case directions.South:
                        animator.SetBool("AthenaBackRightRun", true);
                        break;
                    case directions.East:
                        animator.SetBool("AthenaFrontRightRun", true);
                        break;
                    case directions.West:
                        animator.SetBool("AthenaBackLeftRun", true);
                        break;
                    case directions.NorthEast:
                        animator.SetBool("AthenaFrontRun", true);
                        break;
                    case directions.NorthWest:
                        animator.SetBool("AthenaLeftRun", true);
                        break;
                    case directions.SouthEast:
                        animator.SetBool("AthenaRightRun", true);
                        break;
                    case directions.SouthWest:
                        animator.SetBool("AthenaBackRun", true);
                        break;

                    default:
                        break;
                }
                break;
            case directions.NorthWest:
                switch (moveDirection)
                {
                    case directions.North:
                        animator.SetBool("AthenaFrontRightRun", true);
                        break;
                    case directions.South:
                        animator.SetBool("AthenaBackLeftRun", true);
                        break;
                    case directions.East:
                        animator.SetBool("AthenaBackRightRun", true);
                        break;
                    case directions.West:
                        animator.SetBool("AthenaFrontLeftRun", true);
                        break;
                    case directions.NorthEast:
                        animator.SetBool("AthenaRightRun", true);
                        break;
                    case directions.NorthWest:
                        animator.SetBool("AthenaFrontRun", true);
                        break;
                    case directions.SouthEast:
                        animator.SetBool("AthenaBackRun", true);
                        break;
                    case directions.SouthWest:
                        animator.SetBool("AthenaLeftRun", true);
                        break;

                    default:
                        break;
                }
                break;
            case directions.SouthEast:
                switch (moveDirection)
                {
                    case directions.North:
                        animator.SetBool("AthenaBackLeftRun", true);
                        break;
                    case directions.South:
                        animator.SetBool("AthenaFrontRightRun", true);
                        break;
                    case directions.East:
                        animator.SetBool("AthenaFrontLeftRun", true);
                        break;
                    case directions.West:
                        animator.SetBool("AthenaBackRightRun", true);
                        break;
                    case directions.NorthEast:
                        animator.SetBool("AthenaLeftRun", true);
                        break;
                    case directions.NorthWest:
                        animator.SetBool("AthenaBackRun", true);
                        break;
                    case directions.SouthEast:
                        animator.SetBool("AthenaFrontRun", true);
                        break;
                    case directions.SouthWest:
                        animator.SetBool("AthenaRightRun", true);
                        break;

                    default:
                        break;
                }
                break;
            case directions.SouthWest:
                switch (moveDirection)
                {
                    case directions.North:
                        animator.SetBool("AthenaBackRightRun", true);
                        break;
                    case directions.South:
                        animator.SetBool("AthenaFrontLeftRun", true);
                        break;
                    case directions.East:
                        animator.SetBool("AthenaBackLeftRun", true);
                        break;
                    case directions.West:
                        animator.SetBool("AthenaFrontRightRun", true);
                        break;
                    case directions.NorthEast:
                        animator.SetBool("AthenaBackRun", true);
                        break;
                    case directions.NorthWest:
                        animator.SetBool("AthenaRightRun", true);
                        break;
                    case directions.SouthEast:
                        animator.SetBool("AthenaLeftRun", true);
                        break;
                    case directions.SouthWest:
                        animator.SetBool("AthenaFrontRun", true);
                        break;

                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    private void SetAnimsToFalse()
    {
        animator.SetBool("AthenaFrontRun", false);
        animator.SetBool("AthenaFrontLeftRun", false);
        animator.SetBool("AthenaLeftRun", false);
        animator.SetBool("AthenaFrontRightRun", false);
        animator.SetBool("AthenaRightRun", false);
        animator.SetBool("AthenaBackRightRun", false);
        animator.SetBool("AthenaBackRun", false);
        animator.SetBool("AthenaBackLeftRun", false);
        animator.SetBool("AthenaHacking", false);
    }

}