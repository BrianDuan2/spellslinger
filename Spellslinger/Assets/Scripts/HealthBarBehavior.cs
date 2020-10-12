﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{   
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        //slider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
        Debug.Log("slider value is at " + slider.value);
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low,high,slider.normalizedValue);
    }
}
