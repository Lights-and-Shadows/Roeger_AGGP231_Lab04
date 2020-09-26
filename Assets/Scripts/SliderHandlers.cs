using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandlers : MonoBehaviour
{

    public Slider rotationSlider, scaleSlider;

    public Transform content;

    // Update is called once per frame
    void Update()
    {
        content.rotation = Quaternion.Euler(0f, rotationSlider.value, 0f);
        content.localScale = new Vector3(scaleSlider.value, scaleSlider.value, scaleSlider.value);
    }
}
