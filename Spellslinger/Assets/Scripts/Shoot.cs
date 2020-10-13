using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private int equip = 1;
    public GameObject firePrefab;
    public PlayerController player;
    public int lightningDmg = 20;

    //placeholder for lightning effect  
    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

        //need to change so player can reorganize spells later
        if (Input.GetButtonDown("Fire1"))
        {
            if (equip == 1)
            {
                Fire(); 
            }
            if (equip == 2)
            {
                StartCoroutine(Lightning());
            }
        }
    }
    void Fire(){
        Instantiate(firePrefab, transform.position, transform.rotation);
    }
    IEnumerator Lightning()
    {
        

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
}
