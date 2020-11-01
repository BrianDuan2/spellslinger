using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : Enemy
{   
    //Enemy will fire projectiles
    public GameObject shootPrefab;
    //used for targetting the player
    public PlayerController player;
    //used to control fire rate
    private float fireRate = 0;
    // Start is called before the first frame update
    protected override void Update()
    {
        base.Update();
    }
}
