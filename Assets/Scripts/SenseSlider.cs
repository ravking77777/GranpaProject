using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SenseSlider : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public void OnSliderEvent(float value)
    {
        text.text = $"마우스 X 민감도 { value * 10:F1}%";
    }
}
