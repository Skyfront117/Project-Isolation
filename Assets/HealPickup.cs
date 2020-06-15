using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerController>().HP < 10)
            {
                collision.gameObject.GetComponent<PlayerController>().HP = 10;
                SoundManager.Instance.PlayHeal();
                Destroy(gameObject);
            }
        }
    }
}
