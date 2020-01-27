using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    Transform target;
    public float moveSpeed = 5.0f;
    private float delta = Time.deltaTime;
    Vector3 forward = new Vector3(0, 0, -1);

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position, forward);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
        }
    }

}
