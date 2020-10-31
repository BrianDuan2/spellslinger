﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static public int health = 100;
    static public int maxHealth = 100;
    static public int mana = 100;
    static public int maxMana = 100;
    public float speed = 0;
    public float jumpForce;
    public HealthBar healthBar;
    public HealthBar manaBar;
    public float jumps = 2;
    public int damage = 10;
    private float t = 0;
    private Animator anim;
    private bool facingRight;
    


    void Start()
    {
        facingRight = true;
        healthBar.SetMaxHealth(maxHealth);
        manaBar.SetMaxHealth(maxMana);
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);

        t += Time.deltaTime;
        if (t>=0.2f){
            if (mana < maxMana)
                mana++;
                manaBar.SetHealth(mana);
            t = 0.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            // anim.SetBool("isWalking", true);
        }
            // else{
            // anim.SetBool("isWalking", false);
            // }

        

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            //  anim.SetBool("isWalking", true);     
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
            jumps--;
        }
    }

    

     public void TakeDamage (int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        Debug.Log("dmg = " + damage);
        Debug.Log("health is at" + health);
        if (health <=0)
        {
            Die();
        }
    }
    public bool checkMana(int cost){
        if (mana >= cost){
            return true;
        }
        return false;
    }
    public void useMana(int cost){
        mana -= cost;
        manaBar.SetHealth(mana);
    }
    void Die()
    {
        Destroy(gameObject);
    }

    private void Flip (float horizontal){

        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;

        }


    }
}
