using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private int equip = 1;
    public GameObject firePrefab;
    public GameObject icePrefab;
    public PlayerController player;
    public Rigidbody2D rb;
    public BoxCollider2D lightningHitBox;

    private float t = 0;


    static public int firemana = 10;
    static public int thunmana = 3;
    static public int windmana = 40;
    static public int icemana = 10;


    //placeholder for lightning effect  
    public LineRenderer lineRenderer;
    //wind spell
    public SpriteRenderer sRender;
    public SpriteRenderer lngRender;
    public SpriteRenderer iceRender;
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
         if (Input.GetKey(KeyCode.Alpha4))
        {
            equip = 4;
        }

        //need to change so player can reorganize spells later
        if (Input.GetButtonDown("Fire1"))
        {
            if (equip == 1){
                if (player.checkMana(firemana))
                    Fire(); 
            }
            
            if (equip == 3){
                //add a cooldown
                if (player.checkMana(windmana)){
                    Wind();
                }
            }

            if (equip == 4){
                if (player.checkMana(icemana))
                    Ice(); 
            }
            
        }

        if (Input.GetButton("Fire1")){
            if (equip == 2) {
                t += Time.deltaTime;
                if (t >= 0.1f){
                    player.useMana(thunmana);
                    t = 0.0f;
                }
                if (player.checkMana(thunmana)){
                    Lightning();
                }else{
                    DespawnSprites();
                    t = 0.0f;
                }

                
            }
            /*
            if (equip == 3){
                t += Time.deltaTime;
                if (t >= 0.1f){
                    player.useMana(1);
                    t = 0.0f;
                }
                if (player.checkMana(1)){
                    Wind();
                }else{
                    DespawnSprites();
                    t = 0.0f;
                }
            }*/
        }

        if (Input.GetButtonUp("Fire1")){
            DespawnSprites();
            t = 0.0f;
        }
    }
    void Fire(){
        player.useMana(firemana);
        if (player.checkFlip()){
            Instantiate(firePrefab, transform.position, transform.rotation);
            //Projectiles fire = Projectiles.Create(firePrefab, transform, "Player", "Enemy");
        }else{
            Vector3 rot = transform.rotation.eulerAngles;
            rot = new Vector3(rot.x,rot.y,rot.z+180);
            Instantiate(firePrefab, transform.position, Quaternion.Euler(rot));
        }
    }

    void Ice(){
        player.useMana(icemana);
        iceRender.enabled = true;
    }

    void Lightning(){
        lngRender.enabled = true;
    }

    void Wind(){
        sRender.enabled = true;
        mousePos = GetMouseWorldPosition();
        aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y,aimDirection.x)* Mathf.Rad2Deg;
        Vector2 propelForce = new Vector2(-15f,0);
        propelForce = Rotate(propelForce, angle);
        rb.AddForce(propelForce,ForceMode2D.Impulse);
        player.useMana(windmana);
    }

    void DespawnSprites(){
        sRender.enabled = false;
        lngRender.enabled = false;
        iceRender.enabled = false;
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
