﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CanvasModule : MonoBehaviour
{
    /** initializes raycaster for ui events */
    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("EventCamera").GetComponent<Camera>();
    }

    /** activates the Panel with the specified name, disabling all others */
    public void SetActivePanel(string panelName)
    {
        foreach (Component component in GetComponentsInChildren<RectTransform>(true))
        {
            if (component.gameObject.transform.parent == this.gameObject.transform)
            {
                component.gameObject.SetActive(component.gameObject.name.Equals(panelName));
            }
        }
    }

    /** quits the game */
    public void QuitGame()
    {
        Application.Quit();
    }
}