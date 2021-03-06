﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rb;
    private float t;

  

    void Start()
    {
       // Vector3 aim = GetMouseWorldPosition();
       // rb.velocity = aim.normalized * speed;
       rb.velocity = transform.right * speed;
       t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= 3.0f){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //MOVE THIS TO FIREBALL SUBCLASS
        if (other.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(),GetComponent<Collider2D>());
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("hit the ground");
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit an enemy");
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0f;
        return worldPosition;
    }
}
