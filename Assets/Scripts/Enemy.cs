using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    public int HP = 3;
    public float Attack;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (HP <= 0 ){
            player.GetComponent<Player>().enemiesDefeat += 1;
            Destroy (gameObject); 
        }
    }

    void OnTriggerEnter2D(Collider2D coll){
        print(coll);
       if (coll.gameObject.tag =="Colliders/Hitbox"){
         HP -= 1;
      }


    else if(coll.gameObject.tag =="Colliders/Hurtbox" ){
       coll.GetComponentInParent<Player>().HP -= Attack;
        }
    }
}
