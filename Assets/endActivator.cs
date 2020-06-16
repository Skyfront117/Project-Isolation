using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endActivator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && LevelManager.Instance.level1 && !LevelManager.Instance.getCanEnd())
        {
            Debug.Log("level 3 completed");
            LevelManager.Instance.setEnd(true);
        }
        else if (collision.gameObject.tag == "Player" && !LevelManager.Instance.level1)
        {
            Debug.Log("level 1 not completed");
        }
    }
}
