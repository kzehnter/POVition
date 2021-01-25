using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This module adds any given event camera (graphic raycaster) to the menu canvas.
 *  @author Eduard
 */
public class VR_CanvasModuleInit : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("EventCamera").GetComponent<Camera>();
    }
}
