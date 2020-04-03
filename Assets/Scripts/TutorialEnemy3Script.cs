using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TutorialEnemy3Script : MonoBehaviour
{
    private int HP = 4;

    private GameObject player;
    private float enemySpeed;
    private float nextWaypoint;

    private Path path;
    private int currentWaypoint;
    private bool reachEnd;

    private Seeker seeker;
    private Transform enemy;
    private Rigidbody2D rb2d;
    Vector2 lookDir;

    private Animator animator;
    private int dieParamID;
    private bool dying = false;
    private float dyingTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemySpeed = 4000f;
        nextWaypoint = 128f;
        reachEnd = false;
        currentWaypoint = 0;
        enemy = GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        seeker.StartPath(enemy.position, player.transform.position, onPathComplete);
        rb2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        dieParamID = Animator.StringToHash("Die");
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
            seeker.StartPath(enemy.position, player.transform.position, onPathComplete);
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
                reachEnd = true;
                return;
            }
            else
            {
                reachEnd = false;
            }
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - (Vector2)enemy.position).normalized;
            Vector2 Force = direction * enemySpeed * Time.fixedDeltaTime;

            rb2d.velocity = Force;

            float distance = Vector2.Distance(enemy.position, path.vectorPath[currentWaypoint]);
            if (distance < nextWaypoint)
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
        else
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
}