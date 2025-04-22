using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody2D>(); 
     currentHealth = maxHealth;  
    }

    // Update is called once per frame
    void Update()
    {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical"); 
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
    }
    public void ChangeHealth(int amount){
        if(amount < 0){
            if(isInvincible)return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        //引数（変化量,HPのmin,HPのmax）
        currentHealth = Mathf.Clamp(currentHealth + amount,0,maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

}
