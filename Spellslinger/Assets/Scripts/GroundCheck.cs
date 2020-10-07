using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
     public PlayerController player;
    private float playerJumps;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            //player.jumps = 2;
            player.jumps = 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       // player.jumps--;
       player.jumps--;
    }
}
