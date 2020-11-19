using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerZone : MonoBehaviour
{
    public bool playerInRange;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && playerInRange)
        {
            TriggerAction();
        }
    }
    protected abstract void TriggerAction();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
