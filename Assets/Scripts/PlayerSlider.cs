using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlider : MonoBehaviour
{
    public Slider slider;

    private void Update()
    {
        //SetPlayerHealth(GetComponent<Health>().GetHP());

    }
    public void SetPlayerMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

    }


    public void SetPlayerHealth(int health)
    {
        slider.value = health;
    }
}
