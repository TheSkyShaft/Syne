using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueToUI : MonoBehaviour
{
    public Text output;
    public void UpdateSlider()
    {
        output.text = GetComponent<Slider>().value.ToString() + "%";
    }
}
