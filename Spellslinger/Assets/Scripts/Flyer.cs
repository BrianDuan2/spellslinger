using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : Enemy
{   
    //Enemy will fire projectiles
    public GameObject shootPrefab;
    //used for targetting the player
    public PlayerController player;
    private Vector3 aimDirection;
    //used to control fire rate
    
    private float fireRate = 0;
    // Start is called before the first frame update
    protected override void Update()
    {
        base.Update();
        fireRate += Time.deltaTime;
        if (fireRate >= 3.0f){
            Shoot();
            fireRate = 0;
        }
        
    }

    private float TrackPlayer(){
        aimDirection = (player.transform.position - transform.position).normalized;
        float ang = Mathf.Atan2(aimDirection.y,aimDirection.x)* Mathf.Rad2Deg;
        return ang;
    }

    private void Shoot(){
        float angle = TrackPlayer();
        Vector3 rot = transform.rotation.eulerAngles;
        rot = new Vector3(rot.x,rot.y,rot.z+angle);
        Instantiate(shootPrefab, transform.position, Quaternion.Euler(rot));
    }
}
