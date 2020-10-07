using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
       public GameObject player;
    public float followSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(player.transform.position.x,
                                                                            player.transform.position.y,-10), Time.deltaTime * followSpeed );
    }
}
