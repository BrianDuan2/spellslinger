using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public float speed = 0;
    public float jumpForce;
    public HealthBar healthBar;
    public float jumps = 2;
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
}
