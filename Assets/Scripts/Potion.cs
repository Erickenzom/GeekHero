using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Colliders/Hurtbox" && player.HP < 100)
        {
            player.HP += 20;

            if(player.HP > 100)
                player.HP = 100;

            Destroy(gameObject);
        }
    }
}
