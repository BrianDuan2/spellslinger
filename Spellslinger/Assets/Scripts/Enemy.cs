using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage = 10;
    //public float speed = 1f;
    public HealthBar healthBar;
    public float moveSpeed = 3f;
    public Transform leftwayPoint, rightwayPoint;
    protected bool movingRight = true;
    protected Rigidbody2D rb;

    public float leftMax, rightMax;
    float originalX;
    // Start is called before the first frame update

    protected void Start()
    {
       // originalX = transform.position.x;
       rb = GetComponent<Rigidbody2D>();
       leftwayPoint = GameObject.Find("LeftWayPoint").GetComponent<Transform> ();
       rightwayPoint = GameObject.Find("RightWayPoint").GetComponent<Transform> ();

       healthBar.SetMaxHealth(maxHealth);
    }

    protected void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
    // Update is called once per frame
    void Update()
    {
      //  if (walkingDirection >0 && transform.position.x > originalX + rightMax)
      //  {
        //    walkingDirection *= -1;
         //   transform.localScale = new Vector3(transform.localScale.x *= -1, transform.localScale.y, transform.localScale.z);

      //  }
      //  if(walkingDirection < 0 && transform.position.x < originalX - leftMax)
       // {
        //    walkingDirection *= -1;
         //   transform.localScale = new Vector3(transform.localScale.x *= -1, transform.localScale.y, transform.localScale.z);
        //}
        //transform.Translate(new Vector2(speed, 0) * walkingDirection * Time.deltaTime);
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
}
