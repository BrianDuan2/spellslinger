using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{   
    public SpriteRenderer sRender;
    void OnTriggerStay2D(Collider2D other) {
        if (sRender.enabled == true){
            if (other.gameObject.CompareTag("Enemy")){
                other.gameObject.GetComponent<Enemy>().TakeDamage(5); 
            }
        }
    }
}
