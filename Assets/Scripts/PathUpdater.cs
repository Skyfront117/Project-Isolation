using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathUpdater : MonoBehaviour
{
    float currentTime;
    float maxTime;
    // Start is called before the first frame update
    void Start()
    {
        maxTime = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= maxTime)
        {
            Debug.Log("XD");
            AstarPath.active.Scan();
            currentTime = 0;
        }
    }
}
