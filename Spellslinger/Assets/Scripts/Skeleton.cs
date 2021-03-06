﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{   
    //Enemy will fire projectiles
    public GameObject shootPrefab;
    //used for targetting the player
    public PlayerController player;
    private Vector3 aimDirection;
    private float range = 25;
    //used to control fire rate
    
    private float fireRate = 0;
    private float maxFireRate = 3.0f;
    // Start is called before the first frame update
    protected override void Update()
    {
        base.Update();
        Targeting();
        
    }

    public override void Freeze(){
        base.Freeze();
        rb.AddForce(new Vector2(0,-5),ForceMode2D.Impulse);
    }

    protected void Targeting(){
        if (checkPlayerRange()){
            fireRate += Time.deltaTime;
        }
        if (fireRate >= maxFireRate){
            Shoot();
            fireRate = 0;
        }
    }
    protected float TrackPlayer(){
        aimDirection = (player.transform.position - transform.position).normalized;
        float ang = Mathf.Atan2(aimDirection.y,aimDirection.x)* Mathf.Rad2Deg;
        return ang;
    }

    protected bool checkPlayerRange(){
        if (Vector3.Distance(transform.position, player.transform.position)<= range){
            return true;
        }
        return false;
    }

    protected void Shoot(){
        float angle = TrackPlayer();
        Vector3 rot = transform.rotation.eulerAngles;
        rot = new Vector3(rot.x,rot.y,rot.z+angle);
        Instantiate(shootPrefab, transform.position, Quaternion.Euler(rot));
    }
}
