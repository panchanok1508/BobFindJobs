using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;
    public void SetMaxTime(int time)
    {
        slider.maxValue = time;
        slider.value = time;

        fill.color=gradient.Evaluate(1f);
    }
    public void SetTime(int time)
    {
        slider.value = time;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
