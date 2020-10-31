using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static public int health = 100;
    static public int maxHealth = 100;
    static public int mana = 50;
    static public int maxMana = 50;
    public float speed = 0;
    public float jumpForce;
    public HealthBar healthBar;
    public float jumps = 2;
    public int damage = 10;
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
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
    void Die()
    {
        Destroy(gameObject);
    }
}
