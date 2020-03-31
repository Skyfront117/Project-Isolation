﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyIA : MonoBehaviour
{

    public Transform target;
    private float enemySpeed;
    private float nextWaypoint;

    private Path path;
    private int currentWaypoint;
    private bool reachEnd;

    private Seeker seeker;
    private Transform enemy;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        enemySpeed = 4000f;
        nextWaypoint = 128f;
        reachEnd = false;
        currentWaypoint = 0;
        enemy = GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        seeker.StartPath(enemy.position, target.position, onPathComplete);
        rb2d = GetComponent<Rigidbody2D>();
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
            seeker.StartPath(enemy.position, target.position, onPathComplete);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
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
