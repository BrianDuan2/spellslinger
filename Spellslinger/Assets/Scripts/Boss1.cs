using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Flyer
{
    private bool active = true;
    public float dashTimer = 0f;
    private bool dashing = false;
    protected override void Update(){
        if (active){
            Targeting();
            //check for bounds
            if (rightwayPoint != null && leftwayPoint != null){
                if (transform.position.x >= rightwayPoint.position.x && movingRight == true){
                    movingRight = false;
                    rb.velocity = new Vector2(0,0);
                    dashing = false;
                }          
                if (transform.position.x <= leftwayPoint.position.x && movingRight == false){
                    movingRight = true;
                    rb.velocity = new Vector2(0,0);
                    dashing = false;
                }
            }else{
                rb.velocity = new Vector2(0,0);
            }
            if (dashing == false)
                Roam();
        }
    }

    private void Dash(){
        if (movingRight){
            rb.velocity = new Vector2(20,0);
        }else{
            rb.velocity = new Vector2(-20,0);
        }
    }

    private void Roam(){
        dashTimer+= Time.deltaTime;
        if (dashTimer >= 5.0f){
            dashing = true;
            dashTimer = 0.0f;
            Dash();
        }
        return;
    }
    public void SetActive(bool tf){
        active = tf;
        return;
    }
}
