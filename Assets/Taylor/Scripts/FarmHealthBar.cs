using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FarmHealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxFarmHealth(int farmHealth)
    {
        slider.maxValue = farmHealth;
        slider.value = farmHealth;
    }

    public void SetHealth(int farmHealth)
    {
        slider.value = farmHealth;
    }

}
