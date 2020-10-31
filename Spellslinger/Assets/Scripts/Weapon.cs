using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public PlayerController player;
    private Transform aimTransform;
    private Vector3 aimDirection;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        aimTransform = transform.Find("FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = GetMouseWorldPosition();
        aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y,aimDirection.x)* Mathf.Rad2Deg;
        if (player.checkFlip() ==false){
            angle += 180;
        }
        aimTransform.eulerAngles = new Vector3(0,0,angle);
        
    }

    
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0f;
        return worldPosition;
    }
}
