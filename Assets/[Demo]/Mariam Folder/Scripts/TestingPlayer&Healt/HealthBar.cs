using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI textHealth;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1.0f);
    }

    public void SetHealth(int health)
    {
        textHealth.text = health.ToString();
       slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
