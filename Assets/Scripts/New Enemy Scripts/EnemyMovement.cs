using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    //----> Movement variables
    private Transform target;

    public PlayerController playerScript;

    public float speed;
    public float nextWaypointDistance;

    private Path path;
    private int currentWaypoint;
    private bool reachedEndOfPath;

    private Seeker seeker;
    private Rigidbody2D rb2d;

    //----> Game variables
    private const int startHP = 4;
    private int totalHP = 5;
    public int actualHP = startHP;
    public bool stunned = false;
    public bool attacking = false;

    public float timerStunnedA = 0;
    public float timerStunnedB = 0;
    public float timerAttackingA = 0;
    public float timerAttackingB = 0;

    public Animator animatorTentacles;
    public Animator animator;
    public GameObject corpse;
    public GameObject blood;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        target = GameObject.Find("Player").transform;
        speed = 6000f;
        nextWaypointDistance = 3f;
        currentWaypoint = 0;
        reachedEndOfPath = false;
        seeker = GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();
        seeker.pathCallback = onPathComplete;
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        seeker.StartPath(rb2d.position, target.position);
        animator = GetComponent<Animator>();
    }

    void onPathComplete(Path _path)
    {
        if (!_path.error)
        {
            path = _path;
            currentWaypoint = 0;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb2d.position, target.position, onPathComplete);
        }
    }

    private void FixedUpdate()
    {


    }
    void Update()
    {
        timerStunnedB += Time.deltaTime;
        timerAttackingB += Time.deltaTime;
        if (InputManager.Instance.interactInvisible && playerScript.isInvisible)
        {
            playerScript.isInvisible = false;
        }
        animator.SetBool("moving", false);
        if (!stunned && !playerScript.isInvisible)
        {
            if (true)
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
            Vector2 lookDir = target.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            rb2d.rotation = angle - 90;

        }
        else if (playerScript.isInvisible || stunned)
        {
            rb2d.velocity = new Vector2(0, 0);
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;

            if ((timerStunnedB - timerStunnedA) > 4)
            {
                stunned = false;
                animator.SetBool("stunned", false);
                actualHP = startHP;
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
                Debug.Log("Stunned");
                animator.SetBool("stunned", true);
                stunned = true;
                timerStunnedA = 0;
                timerStunnedB = 0;
                speed += 3000;
                totalHP--;
                if (totalHP == 0)
                {
                    Instantiate(corpse, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(blood, transform.position, transform.rotation);
        }
    }
}
