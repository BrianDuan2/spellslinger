using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{   
    private float t = 0;
    public SpriteRenderer sRender;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) {
        if (sRender.enabled == true){
            if (other.gameObject.CompareTag("Enemy")){
                //need to change
                t+=Time.deltaTime;
                if (t>0.1f){
                    t = 0.0f;
                    other.gameObject.GetComponent<Enemy>().TakeDamage(5);
                }
            }
        }
    }
}
