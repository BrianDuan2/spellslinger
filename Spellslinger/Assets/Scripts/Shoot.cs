using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private int equip = 1;
    public GameObject firePrefab;
    public PlayerController player;
    public Rigidbody2D rb;
    public BoxCollider2D lightningHitBox;
    public int lightningDmg = 20;

  

    //placeholder for lightning effect  
    public LineRenderer lineRenderer;
    //wind spell
    public SpriteRenderer sRender;
    public SpriteRenderer lngRender;
    public Transform aimTransform;
    private Vector3 aimDirection;
    private Vector3 mousePos;
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            equip = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            equip = 2;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            equip = 3;
        }

        //need to change so player can reorganize spells later
        if (Input.GetButtonDown("Fire1"))
        {
            if (equip == 1){
                Fire(); 
            }
            
        }

        if (Input.GetButton("Fire1")){
            if (equip == 2) {
                //StartCoroutine(Lightning());
                Lightning();
            }
            if (equip == 3){
                Wind();
            }
        }

        if (Input.GetButtonUp("Fire1")){
            DespawnSprites();
        }
    }
    void Fire(){
        Instantiate(firePrefab, transform.position, transform.rotation);
    }
    /*
    IEnumerator Lightning(){
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right);

        if(hitInfo)
        {
           Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
           if (enemy != null)
           {
               enemy.TakeDamage(lightningDmg);
           }

           lineRenderer.SetPosition(0, transform.position);
           lineRenderer.SetPosition(1, hitInfo.point);

        }else
        {
             lineRenderer.SetPosition(0,transform.position);
             lineRenderer.SetPosition(1, transform.position + transform.right * 100);
        }

        lineRenderer.enabled = true;
        //waits one second
        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }*/

    void Lightning(){
        lngRender.enabled = true;
    }

    void Wind(){
        sRender.enabled = true;
        mousePos = GetMouseWorldPosition();
        aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y,aimDirection.x)* Mathf.Rad2Deg;
        Vector2 propelForce = new Vector2(-0.2f,0);
        propelForce = Rotate(propelForce, angle);
        rb.AddForce(propelForce,ForceMode2D.Impulse);
    }

    void DespawnSprites(){
        sRender.enabled = false;
        lngRender.enabled = false;
    }

    public static Vector3 GetMouseWorldPosition(){
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0f;
        return worldPosition;
    }
    public static Vector2 Rotate(Vector2 v, float degrees) {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
        
        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}
