using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScript : MonoBehaviour
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
        if (collision.gameObject.tag == "Player" && LevelManager.Instance.getCanEnd() && LevelManager.Instance.level1 && LevelManager.Instance.level2)
        {
            LevelManager.Instance.level1 = false;
            LevelManager.Instance.level2 = false;
            LevelManager.Instance.setEnd(false);
            MusicManager.Instance.music.Stop();
            SceneManager.LoadScene("Victory");
        }
    }
}
