using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSlider : MonoBehaviour
{
    public Slider slider;

    public void SetBossMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

    }


    public void SetBossHealth(int health)
    {
        slider.value = health;
    }
}
