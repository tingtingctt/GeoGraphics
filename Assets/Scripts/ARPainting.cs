﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

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

    private ARRaycastManager aRRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Vector2 touchPosition;
    private Pose hitPose;

    private ColorPicker colorPicker;

    public Text buttonText;
    public Text raycastPositionText;

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

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        colorPicker = GetComponent<ColorPicker>();
    }


    void FixedUpdate()
    {
        if (menuButton.IsShowing == true)
        {
            return;
        }
        if (TryGetTouchPosition(out Vector2 touchPosition))
        {
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
                    StopPainting();
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
            colorPicker.spawnedPaint = spawnedPaintPrefab;
            //PaintManager.instance.paints.Add(spawnedPaintPrefab);
        }
        else
        {
            offsetVector = new Vector3(arCamera.transform.position.x, arCamera.transform.position.y, arCamera.transform.position.z + offset);
            spawnedPaintPrefab.transform.position = arCamera.transform.position + arCamera.transform.forward * offset;
            spawnedPaintPrefab.transform.rotation = arCamera.transform.rotation;
        }
    }

    private void StopPainting()
    {
        spawnedPaintPrefab.transform.position = spawnedPaintPrefab.transform.position;
        //Destroy(spawnedPaintPrefab.GetComponent<ColorPicker>());
        //PaintManager.instance.paints.Remove(spawnedPaintPrefab);
        spawnedPaintPrefab = null;
    }


    private void TwoDPainting()
    {
        if (spawnedPaintPrefab == null)
        {
            spawnedPaintPrefab = Instantiate(paintPrefab, RaycastHitPosition(), arCamera.transform.rotation);
            colorPicker.spawnedPaint = spawnedPaintPrefab;
        }
        else
        {
            spawnedPaintPrefab.transform.position = RaycastHitPosition();
            spawnedPaintPrefab.transform.rotation = arCamera.transform.rotation;
        }
    }

    private Vector3 RaycastHitPosition()
    {
        if (aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            hitPose = hits[0].pose;
            raycastPositionText.text = hitPose.ToString();
            return hitPose.position;
        }
        else
        {
            raycastPositionText.text = hitPose.ToString();
            return hitPose.position;
        }

    }

    public void ChangePaintingType()
    {
        twoDimensional = !twoDimensional;
        if (twoDimensional == true)
        {
            buttonText.text = "2d";
        }
        else
        {
            buttonText.text = "3d";
        }

    }
}