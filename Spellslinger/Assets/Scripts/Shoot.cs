using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private int equip = 1;
    public GameObject firePrefab;
    public PlayerController player;
    public Rigidbody2D rb;
    public int lightningDmg = 20;

    public SpriteRenderer sRender;

    //placeholder for lightning effect  
    public LineRenderer lineRenderer;
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
            if (equip == 2) {
                StartCoroutine(Lightning());
            }
        }

        if (Input.GetButton("Fire1")){
            if (equip == 3){
                Wind();
            }
        }

        if (Input.GetButtonUp("Fire1")){
            DespawnWind();
        }
    }
    void Fire(){
        Instantiate(firePrefab, transform.position, transform.rotation);
    }

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
    }

    void Wind(){
        sRender.enabled = true;
        rb.AddForce(new Vector2(0,0.2f),ForceMode2D.Impulse);
    }

    void DespawnWind(){
        sRender.enabled = false;
    }
}
