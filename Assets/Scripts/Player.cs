using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rig2D;

    float moveX;
    float moveY;
    
    bool isMoving;
    Animator anim; 

    public float HP;
    
    public float maxHP = 100f;

    public Image heart;

    public int enemiesDefeat = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        HP = maxHP;

    }
    
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical"); 
        Move();
        Animation();
        Attack();
        UpdateUI();

        if (HP <= 0){
            SceneManager.LoadScene("SceneLose");
        }

        if(enemiesDefeat >= 3){
            SceneManager.LoadScene("SceneWin");
        }
    }
    
    void Move()
    {
        rig2D.MovePosition(transform.position + new Vector3(moveX, moveY, 0) * Time.deltaTime * moveSpeed);
    }
void Animation(){
    if(moveX == 0 && moveY == 0 ) {
            isMoving = false;
        }   
        else{
           isMoving = true;
        }
        anim.SetBool("isMoving", isMoving);  
        anim.SetFloat("Horizontal", moveX);
        anim.SetFloat("Vertical", moveY);
    }    

    void Attack (){
        if(Input.GetKeyDown(KeyCode.Space)){
            anim.SetTrigger("isAttack");

        }
    }
    void UpdateUI()
    {
        heart.fillAmount = HP / maxHP;
    }
}