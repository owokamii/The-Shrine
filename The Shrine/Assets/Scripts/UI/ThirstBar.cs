using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirstBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxThirst(int thirst)
    {
        slider.maxValue = thirst;
        slider.value = thirst;
    }

    public void SetThirst(int thirst)
    {
        slider.value = thirst;
    }
}