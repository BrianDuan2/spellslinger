using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionText : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    // Start is called before the first frame update
    void Start()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > -8)
        {
            text1.gameObject.SetActive(true);
        }
        if (transform.position.x > 15)
        {
            text1.gameObject.SetActive(false);
        }
        if (transform.position.x > 45)
        {
            text2.gameObject.SetActive(true);
        }
        if (transform.position.x > 65)
        {
            text2.gameObject.SetActive(false);
        }
        if (transform.position.x > 80)
        {
            text3.gameObject.SetActive(true);
        }
        if (transform.position.x > 105)
        {
            text3.gameObject.SetActive(false);
        }
        if (transform.position.x > 125)
        {
            text4.gameObject.SetActive(true);
        }
        if (transform.position.x > 146)
        {
            text4.gameObject.SetActive(false);
        }
    }
}
