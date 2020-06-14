using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TutorialEnemy3Script : MonoBehaviour
{
    private int HP = 4;

    private GameObject player;
    PlayerController playerScript;
    private float enemySpeed;
    private float nextWaypointDistance;

    private Path path;
    private int currentWaypoint;
    private bool reachedEndOfPath;

    private Seeker seeker;
    private Transform enemy;
    private Rigidbody2D rb2d;
    Vector2 lookDir;

    private Animator animator;
    private int dieParamID;
    private bool dying = false;
    private float dyingTimer = 0;

    private float fireRate = 0.5f;
    private float shootingTimer = 0;
    public GameObject bullet;
    private readonly float bulletThrust = 1500;
    public GameObject bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
        enemySpeed = 1000f;
        nextWaypointDistance = 128f;
        reachedEndOfPath = false;
        currentWaypoint = 0;
        enemy = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        seeker.pathCallback = onPathComplete;
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        seeker.StartPath(rb2d.position, player.transform.position);

        animator = GetComponent<Animator>();
        dieParamID = Animator.StringToHash("Die");
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
            seeker.StartPath(rb2d.position, player.transform.position, onPathComplete);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dying)
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
            Vector2 Force = Direction * enemySpeed * Time.deltaTime;
            animator.SetBool("moving", true);
            rb2d.velocity = Force;

            float Distance = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);

            if (Distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
    }

    private void Update()
    {
        if (dying)
        {
            dyingTimer += Time.deltaTime;
            if (dyingTimer > 0.25f)
            {
                Destroy(this.gameObject);
            }
        }
        else if (!playerScript.isInvisible)
        {
            lookDir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb2d.rotation = angle;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HP--;
            if (HP < 1)
            {
                TutorialManager.Instance.enemiesCount--;
                animator.SetTrigger(dieParamID);
                dying = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shootingTimer += Time.fixedDeltaTime;
            if (shootingTimer > fireRate)
            {
                GameObject temporalBullet = Instantiate(bullet, bulletSpawner.transform.position, transform.rotation);
                temporalBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletThrust, ForceMode2D.Impulse);
                shootingTimer = 0;
                SoundManager.Instance.PlayShot();
                TutorialManager.Instance.dialogueFirstEnemyShooting();
            }
        }
    }
}