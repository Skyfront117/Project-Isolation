using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class xd : MonoBehaviour
{
    //----> Movement variables
    public Transform target;

    public float speed;
    public float nextWaypointDistance;

    private Path path;
    private int currentWaypoint;
    private bool reachedEndOfPath;

    private Seeker seeker;
    private Rigidbody2D rb2d;

    //----> Game variables
    private const int startHP = 4;
    public int actualHP = startHP;
    public bool stunned = false;
    public bool attacking = false;

    float timerStunnedA = 0;
    float timerStunnedB = 0;
    float timerAttackingA = 0;
    float timerAttackingB = 0;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        speed = 4000f;
        nextWaypointDistance = 3f;
        currentWaypoint = 0;
        reachedEndOfPath = false;
        seeker = GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();
        seeker.pathCallback = onPathComplete;
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

    private void FixedUpdate()
    {
        timerStunnedB += Time.deltaTime;
        timerAttackingB += Time.deltaTime;
        if (!stunned)
        {
            if (attacking)
            {
                // animacion

                if((timerAttackingB -timerAttackingA) < 0.5f)
                {
                    attacking = false;
                }                
            }
            else
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

                rb2d.velocity = Force;

                float Distance = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);

                if (Distance < nextWaypointDistance)
                {
                    currentWaypoint++;
                }
            }
            Vector2 lookDir = target.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            rb2d.rotation = angle;
        }
        else
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;

            if ((timerStunnedB - timerStunnedA) > 4)
            {
                stunned = false;
                actualHP = startHP;
                rb2d.constraints = RigidbodyConstraints2D.None;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!stunned && collision.gameObject.tag == "Bullet")
        {
            actualHP--;
            if (actualHP < 1)
            {
                stunned = true;
                attacking = false;
                timerStunnedA = 0;
                timerStunnedB = 0;
            }
        }
    }
}
