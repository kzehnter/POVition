using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class VR_InteractionLock : MonoBehaviour
{
    public GameObject raycaster;
    public TeleportationController teleportationController;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<HandCollider>() == null)
        {
            SetTeleportationLock(true);
            raycaster.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<HandCollider>() == null)
        {
            SetTeleportationLock(false);
            raycaster.SetActive(true);
        }
    }

    private void SetTeleportationLock(bool isLocked)
    {
        foreach (GameObject obj in teleportationController.TeleportationMarkers)
        {
            obj.GetComponent<TeleportMarkerBase>().SetLocked(isLocked);
        }
    }
}