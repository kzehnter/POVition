using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_CanvasModuleInit : MonoBehaviour
{
    /** initializes raycaster for ui events */
    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("EventCamera").GetComponent<Camera>();
    }
}
