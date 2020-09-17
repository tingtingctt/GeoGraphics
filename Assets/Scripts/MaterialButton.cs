using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialButton : MonoBehaviour
{
    public Image buttonImage;
    public ARPainting aRPainting;
    //public Color testColor;
    //public GameObject cube;
    //public Image testImage;
    //public Text testText;
    public GameObject materialPaintPrefab;

    private Color buttonColor;
    // Material paintPrefabMaterial;
    private Material paintPrefabMaterial;

    private void Start()
    {
        buttonColor = buttonImage.color;
        Debug.Log("Button color is:" + buttonColor);
    }

    public void ChangePaintPrefabColor()
    {
        TrailRenderer trailRenderer = aRPainting.paintPrefab.GetComponent<TrailRenderer>();
        paintPrefabMaterial = aRPainting.paintPrefab.GetComponent<TrailRenderer>().material;
        Debug.Log("Paint Prefab Material is:" + paintPrefabMaterial);
        //paintPrefabMaterial.color = buttonColor;
        trailRenderer.material.color = buttonColor;
        //cube.GetComponent<Renderer>().material.color = buttonColor;
        //cube.GetComponent<Renderer>().material.color = testColor;
        //testImage.color = trailRenderer.material.color;
        //testText.text = $"{paintPrefabMaterial}";
        aRPainting.paintPrefab = materialPaintPrefab;

        MenuButton.instance.HideButtons();
    }
}
