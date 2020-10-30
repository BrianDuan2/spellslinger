using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public SpriteRenderer sRender;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (sRender.enabled == true){
            if (other.gameObject.CompareTag("Enemy")){
                //need to change
                other.gameObject.GetComponent<Enemy>().TakeDamage(1);
            }
        }
    }
}
