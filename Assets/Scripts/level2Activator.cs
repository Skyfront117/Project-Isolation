using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2Activator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && LevelManager.Instance.level1 && !LevelManager.Instance.level2)
        {
            Debug.Log("level 2 completed");
            LevelManager.Instance.level2 = true;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && !LevelManager.Instance.level1)
        {
            Debug.Log("level 1 not completed");
        }
    }
}
