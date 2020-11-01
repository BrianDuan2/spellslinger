using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage = 10;
    public HealthBar healthBar;
    public float moveSpeed = 3f;
    public Transform leftwayPoint, rightwayPoint;
    protected bool movingRight = true;
    protected Rigidbody2D rb;
    // Start is called before the first frame update

    protected void Start()
    {
       // originalX = transform.position.x;
       rb = GetComponent<Rigidbody2D>();

       healthBar.SetMaxHealth(maxHealth);
       Move();
    }

    protected void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        if (rightwayPoint != null && leftwayPoint != null){
            if (transform.position.x >= rightwayPoint.position.x){
                movingRight = false;
                Move();
            }          
            if (transform.position.x <= leftwayPoint.position.x){
                movingRight = true;
                Move();
            }
        }else{
            rb.velocity = new Vector2(0,0);
        }

        
    }
    public void TakeDamage (int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        Debug.Log("health is at" + health);
        if (health <=0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

    protected void Move(){
        if (movingRight){
            rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
        }else{
            rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
        }
    }
}
