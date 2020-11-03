using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SpellBar : MonoBehaviour
{
    private int equip = 1;
    public Sprite fire1;
    public Sprite fire2;
    public Sprite thunder1;
    public Sprite thunder2;
    public Sprite wind1;
    public Sprite wind2;
    public Sprite ice1;
    public Sprite ice2;
    public GameObject firespell;
    public GameObject thunderspell;
    public GameObject windspell;
    public GameObject icespell;

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
        if (equip == 1)
        {
            firespell.GetComponent<Image>().sprite = fire2;
            thunderspell.GetComponent<Image>().sprite = thunder1;
            windspell.GetComponent<Image>().sprite = wind1;
            icespell.GetComponent<Image>().sprite = ice1;
        }
        if (equip == 2)
        {
            firespell.GetComponent<Image>().sprite = fire1;
            thunderspell.GetComponent<Image>().sprite = thunder2;
            windspell.GetComponent<Image>().sprite = wind1;
            icespell.GetComponent<Image>().sprite = ice1;
        }
        if (equip == 3)
        {
            firespell.GetComponent<Image>().sprite = fire1;
            thunderspell.GetComponent<Image>().sprite = thunder1;
            windspell.GetComponent<Image>().sprite = wind2;
            icespell.GetComponent<Image>().sprite = ice1;
        }
        if (equip == 4)
        {
            firespell.GetComponent<Image>().sprite = fire1;
            thunderspell.GetComponent<Image>().sprite = thunder1;
            windspell.GetComponent<Image>().sprite = wind1;
            icespell.GetComponent<Image>().sprite = ice2;
        }

    }
}