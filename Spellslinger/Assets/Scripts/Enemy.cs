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
    public SpriteRenderer sRender;

    public float freezeTime = 0;
    public bool frozen = false;
    private Vector2 oldVelocity;
    Boss1 boss1;
    // Start is called before the first frame update

    protected void Start()
    {
        // originalX = transform.position.x;
        boss1 = FindObjectOfType<Boss1>();
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
        if (freezeTime >= 0){
            freezeTime -= Time.deltaTime;
            if (freezeTime <= 0 && frozen == true){
                Unfreeze();
            }
        }
        if (rightwayPoint != null && leftwayPoint != null){
            if (transform.position.x >= rightwayPoint.position.x){
                movingRight = false;
                
            }          
            if (transform.position.x <= leftwayPoint.position.x){
                movingRight = true;
            }
            Move();
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
            if(gameObject.name=="Boss 1")
            {
                Debug.Log("Boss Died!!");
                boss1.ShowDoor();
            }
            Die();
        }
    }

    public virtual void Freeze(){
        oldVelocity = rb.velocity;
        rb.velocity = new Vector2(0,0);
        freezeTime = 5.0f;
        frozen = true;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-1) * 10, ForceMode2D.Impulse);
        sRender.color = Color.blue;
    }

    public void Unfreeze(){
        rb.velocity = oldVelocity;
        frozen = false;
        freezeTime = 0;
        sRender.color = Color.white;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    void Die()
    {
        Destroy(gameObject);
    }

    protected void Move(){
        if (frozen == false){
            if (movingRight){
                rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
            }else{
                rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
            }
        }
    }
}
