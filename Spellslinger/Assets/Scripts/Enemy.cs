using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float speed = 1f;
    public float leftMax, rightMax;
    float walkingDirection = 1.0f;
    float originalX;
    // Start is called before the first frame update

    void Start()
    {
        originalX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (walkingDirection >0 && transform.position.x > originalX + rightMax)
        {
            walkingDirection *= -1;
            transform.localScale = new Vector3(transform.localScale.x *= -1, transform.localScale.y, transform.localScale.z);

        }
        if(walkingDirection < 0 && transform.position.x < originalX - leftMax)
        {
            walkingDirection *= -1;
            transform.localScale = new Vector3(transform.localScale.x *= -1, transform.localScale.y, transform.localScale.z);
        }
        transform.Translate(new Vector2(speed, 0) * walkingDirection * Time.deltaTime);
    }
    public void TakeDamage (int damage)
    {
        health -= damage;
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
