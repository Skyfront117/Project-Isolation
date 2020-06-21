using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleScript : MonoBehaviour
{
    public EnemyMovement ParentScript;
    public GameObject Player;
    PlayerController PlayerController;

    void Start()
    {
        Player = GameObject.Find("Player");
        ParentScript = gameObject.GetComponentInParent<EnemyMovement>();
        PlayerController = Player.GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.score -= 100;
            PlayerController.HP--;
            SoundManager.Instance.PlayDamage();
        }
    }
}
