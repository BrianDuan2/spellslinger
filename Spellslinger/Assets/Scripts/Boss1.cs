using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Flyer
{
    private bool active = false;
    public float dashTimer = 0f;
    public float dashFreq = 5.0f;
    private bool dashing = false;
    public bool final = false;
    public Transform upperBoundPivot;
    public Transform lowerBoundPivot;
    private bool movingUp = false;
    public Door door;

    public LightningSpawner l0;
    public LightningSpawner l1;
    public LightningSpawner l2;
    public LightningSpawner l3;
    public LightningSpawner l4;

    private float lTimer = 0f;
    private int pick;

    protected override void Update() {
        if (active) {
            Targeting();
            //check for bounds
            if (rightwayPoint != null && leftwayPoint != null) {
                if (transform.position.x >= rightwayPoint.position.x && movingRight == true) {
                    movingRight = false;
                    dashing = false;
                    rb.velocity = new Vector2(0, 0);
                }
                if (transform.position.x <= leftwayPoint.position.x && movingRight == false) {
                    movingRight = true;
                    dashing = false;
                    rb.velocity = new Vector2(0, 0);
                }
            } else {
                rb.velocity = new Vector2(0, 0);
            }
            if (transform.position.y <= lowerBoundPivot.position.y && movingUp == false) {
                movingUp = true;
            }
            if (transform.position.y >= upperBoundPivot.position.y && movingUp == true) {
                movingUp = false;
            }
            if (dashing == false)
                Roam();

            if (final == true){
            //Set lightning spawns on a timer for final boss
                lTimer += Time.deltaTime;
                if (lTimer >= 2.0f){
                    pick = Random.Range(0,5);
                    switch(pick)
                    {
                        case 0:
                            Lightning(l0);
                        break;
                        case 1:
                            Lightning(l1);
                        break;
                        case 2:
                            Lightning(l2);
                        break;
                        case 3:
                            Lightning(l3);
                        break;
                        case 4:
                            Lightning(l4);
                        break;
                    }
                    lTimer = 0.0f;
                }
            }
        }
    }

    private void Dash() {
        if (movingRight) {
            rb.velocity = new Vector2(20, 0);
        } else {
            rb.velocity = new Vector2(-20, 0);
        }
    }

    private void Roam() {
        dashTimer += Time.deltaTime;
        if (movingUp) {
            rb.velocity = new Vector2(0, 3);
        } else {
            rb.velocity = new Vector2(0, -3);
        }
        if (dashTimer >= dashFreq) {
            dashing = true;
            dashTimer = 0.0f;
            Dash();
        }
        return;
    }

    private void Lightning(LightningSpawner l){
        l.SpawnL();
    }

    public void SetActive(bool tf) {
        active = tf;
        return;
    }
    public void ShowDoor()
    {
        door.setActive();
    }

    protected override void Die(){
        ShowDoor();
        Destroy(gameObject);
    }
}
