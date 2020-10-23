using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ColorPicker : MonoBehaviour
{
    public GameObject spawnedPaint;

    public Slider colorSlider;

    //private ARPainting aRPainting;


    void Start()
    {
        //Debug.Log("enabled");

            colorSlider.onValueChanged.AddListener(delegate { ChangeColor(); });
            //aRPainting = GetComponent<ARPainting>();

    }

    private void OnDisable()
    {
        
    }

    public void ChangeColor()
    {
        //GameObject aRPaintingPaintPrefab = aRPainting.spawnedPaints[aRPainting.lastPaint];
        //if (aRPainting.spawnedPaintPrefab != null)
        //{

        //    aRPaintingPaintPrefab.GetComponent<TrailRenderer>().material.color = Color.HSVToRGB(colorSlider.value, 0.5f, 1);
        //}


        spawnedPaint.GetComponent<TrailRenderer>().material.color = Color.HSVToRGB(colorSlider.value, 0.5f, 1);
    }
}
