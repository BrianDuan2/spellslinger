using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    

    // Start is called before the first frame update
    void Update()
    {
        if (transform.position.x > rightwayPoint.position.x)
            movingRight = false;
        if (transform.position.x < leftwayPoint.position.x)
            movingRight = true;

        if (movingRight)
            moveRight();
        else
            moveLeft();
    }

    void moveRight()
    {
        movingRight = true;
        rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);

    }

    void moveLeft()
    {
        movingRight = false;
        rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);

    }
    // Update is called once per frame
    

    
}
