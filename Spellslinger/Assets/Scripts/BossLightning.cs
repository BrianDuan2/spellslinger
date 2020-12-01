using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLightning : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    void Start()
    {
       rb.velocity = new Vector2(0,-1) * speed;

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //MOVE THIS TO FIREBALL SUBCLASS
        if (other.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(),GetComponent<Collider2D>());
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("hit the ground");
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit the player");
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
