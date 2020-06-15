using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform pfFieldOfView;
    public FOVScript fieldOfView;
    //----> Movement variables
    private Transform target;

    public PlayerController playerScript;

    public float speed;
    public float nextWaypointDistance;

    private Path path;
    private int currentWaypoint;
    private bool reachedEndOfPath;

    private Seeker seeker;
    public Rigidbody2D rb2d;

    //----> Game variables
    private const int startHP = 4;
    public int totalHP = 5;
    public int actualHP = startHP;
    public bool stunned = false;
    public bool attacking = false;
    public bool moving = true;
    public bool alert = false;
    public bool ultraAlert = false;
    public bool damageTaken = false;

    private float timerStunnedA = 0;
    private float timerStunnedB = 4;
    public float timerMaxBlood = 2.0f;
    public float timerBlood = 0;
    public float ATtimer = 0;
    public float ATmax = 2.0f;
    public float AlertTimer = 0;
    private float AlertMax = 10.0f;
    public float UltraAlertTimer = 0;
    private float UltraAlertMax = 2.0f;

    public Animator animatorTentacles;
    public Animator animator;
    public GameObject corpse;
    public GameObject blood;
    public GameObject bloodDrop1;
    public GameObject bloodDrop2;
    public GameObject bloodDrop3;
    public GameObject bloodSpray;
    public GameObject forward;

    void Start()
    {
        target = forward.transform;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        speed = 1000f;
        nextWaypointDistance = 0.3f;
        currentWaypoint = 0;
        reachedEndOfPath = false;
        seeker = GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();
        seeker.pathCallback = onPathComplete;
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        seeker.StartPath(rb2d.position, target.position);
        animator = GetComponent<Animator>();

        fieldOfView = Instantiate(pfFieldOfView, null).GetComponent<FOVScript>();
        fieldOfView.setPlayer(0);
    }

    void onPathComplete(Path _path)
    {
        if (!_path.error)
        {
            path = _path;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb2d.position, target.position, onPathComplete);
        }
    }

    void Update()
    {
        if (alert || ultraAlert)
        {
            if (!GameManager.instance.alert)
            {
                GameManager.instance.alert = true;
            }
        }
        if (GameManager.instance.darkness)
        {
            gameObject.GetComponent<Renderer>().sortingOrder = -1;
            gameObject.GetComponentInChildren<TentacleScript>().GetComponent<Renderer>().sortingOrder = -1;
        }
        if (fieldOfView.target)
        {
            target = GameObject.Find("Player").transform;
        }
        else
        {
            target = forward.transform;
        }
        if (playerScript.isInvisible)
        {
            if (ultraAlert)
            {
                fieldOfView.setDistance(150.0f);
                fieldOfView.setFov(25.0f);
            }
            else if (alert)
            {
                fieldOfView.setDistance(30.0f);
                fieldOfView.setFov(180.0f);
            }
            else
            {
                fieldOfView.setDistance(20.0f);
                fieldOfView.setFov(180.0f);
            }
        }
        else
        {
            if (ultraAlert)
            {
                fieldOfView.setDistance(200.0f);
                fieldOfView.setFov(25.0f);
            }
            else if (alert)
            {
                fieldOfView.setDistance(80.0f);
                fieldOfView.setFov(360.0f);
            }
            else
            {
                fieldOfView.setDistance(50.0f);
                fieldOfView.setFov(360.0f);
            }
        }
        Vector3 aimDir = transform.up;
        fieldOfView.setOrigin(transform.position);
        fieldOfView.setAimDirection(aimDir);
        timerBlood += Random.Range (Time.deltaTime * 8, 0);
        if (timerBlood >= timerMaxBlood)
        {
            if (totalHP == 4)
            {
                Instantiate(bloodDrop1, transform.position, transform.rotation);
            }
            else if (totalHP == 3 || totalHP == 2)
            {
                Instantiate(bloodDrop2, transform.position, transform.rotation);
            }
            if (totalHP == 1)
            {
                Instantiate(bloodDrop3, transform.position, transform.rotation);
            }
            timerBlood = 0;
        }
        if (stunned)
        {
            timerStunnedA += Time.deltaTime;
        }
        animator.SetBool("moving", false);
        if (ultraAlert)
        {
            if (!fieldOfView.target || stunned)
            {
                UltraAlertTimer += Time.deltaTime;
            }
            if (alert)
            {
                alert = false;
            }
            if (UltraAlertTimer >= UltraAlertMax)
            {
                UltraAlertTimer = 0;
                ultraAlert = false;
                alert = true;
                speed -= 1000;
            }
        }
        if (alert)
        {
            if (!fieldOfView.target || stunned)
            {
                AlertTimer += Time.deltaTime;
            }
            if (AlertTimer >= AlertMax)
            {
                AlertTimer = 0;
                alert = false;
                GameManager.instance.alert = false;
            }
        }
        if (alert && moving || ultraAlert && moving)
        {
            if (!stunned)
            {
                if (path == null) { return; }
                if (currentWaypoint >= path.vectorPath.Count)
                {
                    reachedEndOfPath = true;
                    return;
                }
                else
                {
                    reachedEndOfPath = false;
                }
                Vector2 Direction = ((Vector2)path.vectorPath[currentWaypoint] - rb2d.position).normalized;
                Vector2 Force = Direction * speed * Time.deltaTime;
                animator.SetBool("moving", true);
                rb2d.velocity = Force;

                float Distance = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);

                if (Distance < nextWaypointDistance)
                {
                    currentWaypoint++;
                }
            }
            if (fieldOfView.target)
            {
                Vector2 lookDir = target.position - transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
                rb2d.rotation = angle - 90;
            }

        }
        if (stunned)
        {
            moving = false;
            rb2d.velocity = new Vector2(0, 0);
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;

            if (timerStunnedA > timerStunnedB)
            {
                timerStunnedA = 0;
                stunned = false;
                moving = true;
                animator.SetBool("stunned", false);
                actualHP = startHP;
            }
        }
        if (!alert && !ultraAlert)
        { 
            rb2d.velocity = new Vector2(0, 0);
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (!alert && !ultraAlert && !stunned && fieldOfView.target)
        {
            alert = true;
        }
        if (attacking)
        {
            moving = false;
            ATtimer = 0;
            animatorTentacles.SetTrigger("Attack");
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            attacking = false;
        }
        if (!moving)
        {
            rb2d.velocity = new Vector2(0, 0);
            if (ATtimer < ATmax)
            {
                ATtimer += Time.deltaTime;
            }
            else
            {
                moving = true;
                ATtimer = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!stunned && collision.gameObject.tag == "Bullet")
        {
            actualHP--;
            if (actualHP < 1)
            {
                animator.SetBool("stunned", true);
                stunned = true;
                speed += 200;
                totalHP--;
                if (totalHP == 0)
                {
                    Instantiate(corpse, transform.position, collision.transform.rotation);
                    Destroy(gameObject);
                }
            }
            else
            {
                if (!ultraAlert && !fieldOfView.target)
                {
                    speed += 1000;
                    ultraAlert = true;
                    Vector2 lookDir = GameObject.Find("Player").transform.position - transform.position;
                    float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
                    rb2d.rotation = angle - 90;
                }
                else if (!ultraAlert && fieldOfView.target)
                {
                    AlertTimer = 0;
                }
                if (!alert && ultraAlert)
                {
                    UltraAlertTimer = 0;
                }
           
            }
        }
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject bloodSplatter = Instantiate(blood, collision.contacts[0].point, collision.transform.rotation);
            Instantiate(bloodSpray, collision.contacts[0].point, collision.transform.rotation);
            timerMaxBlood -= 0.02f;
            ATmax -= 0.05f;
            SoundManager.Instance.PlayBlood();
        }
    }
}
