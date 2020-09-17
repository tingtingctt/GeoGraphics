using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public static MenuButton instance;
    public GameObject[] materialButtons;
    private bool enable=false;

    public Text enableText;
    public Text isShowingText;

    public bool IsShowing
    {
        //accesser
        get
        {
            return enable;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        enableText.text = enable.ToString();
        isShowingText.text = IsShowing.ToString();
    }

    public void ShowButtons()
    {
        foreach(GameObject button in materialButtons)
        {
            button.SetActive(true);
            enable = true;
        }
    }

    public void HideButtons()
    {
        foreach (GameObject button in materialButtons)
        {
            button.SetActive(false);
            enable = false;
        }
    }

    public void ToggleButtons()
    {
        enable = !enable;

        if (enable == true)
        {
            ShowButtons();
        }
        else
        {
            HideButtons();
        }
    }

}
