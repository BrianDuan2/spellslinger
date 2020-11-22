using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    public TilemapRenderer sprite;
    public CompositeCollider2D collider;
    public int req;
    void Start(){
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")){
            PlayerController p = other.gameObject.GetComponent<PlayerController>();
            if (p.checkCrystals() >= req){
                sprite.enabled = false;
                collider.enabled = false;
                p.addCrystals(-req);
            }
        }
    }
}


