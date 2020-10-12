﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
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
