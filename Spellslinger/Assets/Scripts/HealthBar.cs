using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    public Slider slider;
    public Vector3 Offset = new Vector3(0,2,0);
     public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = (pos + Offset);
    }
   
}
