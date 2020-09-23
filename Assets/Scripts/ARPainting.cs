using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class ARPainting : MonoBehaviour
{
    public GameObject paintPrefab;
    public Camera arCamera;
    public float offset;
    public MenuButton menuButton;
    public bool twoDimensional;
    private bool onTouchHold;
    private GameObject spawnedPaintPrefab;
    private Vector3 offsetVector;
    // void = not returning anything
    // method: Vector3, Boolean, String, (returns this type of value)
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
    void FixedUpdate()
    {
        if (menuButton.IsShowing == true)
        {
            return;
        }
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //if (touch.phase == TouchPhase.Began)
            if (touch.phase == TouchPhase.Stationary)
            {
                onTouchHold = true;
                if (onTouchHold == true)
                {
                    if (twoDimensional)
                    {
                        TwoDPainting();
                    }
                    else
                    {
                        ThreeDPainting();
                    }
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
                if (twoDimensional)
                {
                    StopTwoDPainting();
                }
                else
                {
                    StopThreeDPainting();
                }
            }
        }
    }
    private void ThreeDPainting()
    {
        if (spawnedPaintPrefab == null)
        {
            offsetVector = new Vector3(arCamera.transform.position.x, arCamera.transform.position.y, arCamera.transform.position.z + offset);
            spawnedPaintPrefab = Instantiate(paintPrefab, arCamera.transform.position, arCamera.transform.rotation);
            //PaintManager.instance.paints.Add(spawnedPaintPrefab);
        }
        else
        {
            offsetVector = new Vector3(arCamera.transform.position.x, arCamera.transform.position.y, arCamera.transform.position.z + offset);
            spawnedPaintPrefab.transform.position = arCamera.transform.position + arCamera.transform.forward * offset;
            spawnedPaintPrefab.transform.rotation = arCamera.transform.rotation;
        }
    }
    private void StopThreeDPainting()
    {
        spawnedPaintPrefab.transform.position = spawnedPaintPrefab.transform.position;
        //PaintManager.instance.paints.Remove(spawnedPaintPrefab);
        spawnedPaintPrefab = null;
    }
    private void TwoDPainting()
    {
    }

    private void StopTwoDPainting()
    {
    }
}
