using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerZone : MonoBehaviour
{
    public bool playerInRange;
    public Door door;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && playerInRange)
        {
            TriggerAction();
        }
    }
    protected abstract void TriggerAction();
    protected abstract void EnableTip();
    protected abstract void DisableTip();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            EnableTip();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            DisableTip();
        }
    }
}
