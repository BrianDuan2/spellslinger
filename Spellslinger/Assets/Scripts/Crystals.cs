using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerController>().addCrystals(1);
            Destroy(gameObject);
        }
    }
}
