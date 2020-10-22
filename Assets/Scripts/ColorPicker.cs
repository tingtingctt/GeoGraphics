using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ColorPicker : MonoBehaviour
{

    public Slider colorSlider;

    private ARPainting aRPainting;


    // Start is called before the first frame update
    void Start()
    {
        colorSlider.onValueChanged.AddListener(delegate { ChangeColor(); });
        aRPainting = GetComponent<ARPainting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {
        GameObject aRPaintingPaintPrefab = aRPainting.paintPrefab;
        aRPaintingPaintPrefab.GetComponent<TrailRenderer>().material.color = Color.HSVToRGB(colorSlider.value, 1, 1);
    }
}
