using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
     public PlayerController player;
     public Collider2D plat;
    private float playerJumps;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player falls through platforms when they hold S
        if(Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.IgnoreCollision(plat,GetComponent<Collider2D>(),true);       
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            Physics2D.IgnoreCollision(plat,GetComponent<Collider2D>(),false);       
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {  
        if(collision.gameObject.CompareTag("Ground"))
        {
            player.jumps = 2;
        }
        if(collision.gameObject.CompareTag("Platforms"))
        {
            player.jumps = 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       player.jumps--;
    }
}
