using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Flyer
{
    private bool active = false;
    public float dashTimer = 0f;
    private bool dashing = false;
    public bool final = false;
    public Transform upperBoundPivot;
    public Transform lowerBoundPivot;
    private bool movingUp = false;
    public Door door;
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
        if (dashTimer >= 5.0f) {
            dashing = true;
            dashTimer = 0.0f;
            Dash();
        }
        return;
    }

    private void Rain(){
        
    }
    public void SetActive(bool tf) {
        active = tf;
        return;
    }
    public void ShowDoor()
    {
        door.setActive();
    }
}
