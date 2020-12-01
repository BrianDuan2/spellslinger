using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpawner : MonoBehaviour
{
    public GameObject lightningPrefab;
    // Start is called before the first frame update
    public void SpawnL(){
        Instantiate(lightningPrefab, transform.position, transform.rotation);
    }
}
