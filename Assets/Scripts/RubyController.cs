using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;
    public int maxHealth =5;
    int currentHealth;
    public int health{get{return currentHealth;}}
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rb;

    Animator anim;
    Vector2 lookDirection = new Vector2(1f,0);
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody2D>(); 
     currentHealth = maxHealth;  
     anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical"); 

    Vector2 move = new Vector2(horizontal,vertical);
    if(move.sqrMagnitude > 0f){
        lookDirection.Set(move.x,move.y);
        lookDirection.Normalize();
    }
    anim.SetFloat("Look X",lookDirection.x);
    anim.SetFloat("Look Y",lookDirection.y);
    anim.SetFloat("Speed",move.magnitude);

    Vector2 position = rb.position;
    position.x = position.x +speed *horizontal*Time.deltaTime;
    position.y = position.y + speed * vertical*Time.deltaTime;
    rb.MovePosition(position);

    if(isInvincible){
        invincibleTimer -= Time.deltaTime;
        if(invincibleTimer < 0 ){
            isInvincible = false;
        }
    }
    if(Input.GetKeyDown(KeyCode.C)){
        Launch();
    }
    }
    public void ChangeHealth(int amount){
        if(amount < 0){
            if(isInvincible)return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
            anim.SetTrigger("Hit");
        }

        //引数（変化量,HPのmin,HPのmax）
        currentHealth = Mathf.Clamp(currentHealth + amount,0,maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
    void Launch(){
        GameObject cogBullet = Instantiate(
            prefab,rb.position+Vector2.up*0.5f,
            Quaternion.identity
        );
        CogBulletController cogCon = cogBullet.GetComponent<CogBulletController>();
        cogCon.Launch(lookDirection,5f);
        anim.SetTrigger("Launch");
    }

}
