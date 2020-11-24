using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Store : MonoBehaviour, IPointerEnterHandler
{
    public Sprite nothover;
    public Sprite hover;
    public GameObject ShowText;
    public GameObject ConfirmText;
    public GameObject UngradedText;
    public GameObject GuideText;
    public GameObject SpellBox;

    void Start()
    {
        ShowText.gameObject.SetActive(false);
        ConfirmText.gameObject.SetActive(false);
        UngradedText.gameObject.SetActive(false);
    }

    void Update()
    {
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Debug.Log("Currently hovering " + name, this);
    }

    public void OnHover()
    {
        GameObject.Find(name + "Box").GetComponent<Image>().sprite = hover;
        ShowText.gameObject.SetActive(true);
    }

    public void OnHoverAway()
    {
        GameObject.Find(name + "Box").GetComponent<Image>().sprite = nothover;
        ShowText.gameObject.SetActive(false);
    }

    public void SpellSelect()
    {
        ConfirmText.gameObject.SetActive(true);
    }

    public void OnClickYes()
    {
        UngradedText.gameObject.SetActive(true);
        GuideText.gameObject.SetActive(false);
        ConfirmText.gameObject.SetActive(false);
        SpellBox.gameObject.SetActive(false);
        if(name == "FireSpell")
        {
            Shoot.firemana -= 2;
        }else if (name == "ThurderSpell")
        {
            Shoot.thunmana -= 1;
        }
        else if (name == "WindSpell")
        {
            Shoot.windmana -= 10;
        }
        else if (name == "IceSpell")
        {
            Shoot.icemana -= 2;
        }
    }

    public void OnClickNo()
    {
        ConfirmText.gameObject.SetActive(false);
    }

}
