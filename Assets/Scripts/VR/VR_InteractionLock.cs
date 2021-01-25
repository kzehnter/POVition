using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

/** This module locks teleportation and the physics raycaster when intersecting with another collider.
 *  This is meant to prevent noclipping with the controller in vr mode.
 *  @author Eduard
 */
public class VR_InteractionLock : MonoBehaviour
{
    /** Raycaster to be locked. */
    public GameObject raycaster;

    public TeleportationController teleportationController;

    /** Activates the interaction lock for all colliders which are not part of the controller itself */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<HandCollider>() == null)
        {
            SetTeleportationLock(true);
            raycaster.SetActive(false);
        }
    }

    /** Deactivates the interaction lock for all colliders which are not part of the controller itself */
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<HandCollider>() == null)
        {
            SetTeleportationLock(false);
            raycaster.SetActive(true);
        }
    }

    /** Sets the locking state for all TeleportMarkerBase objects found in the level scene. */
    private void SetTeleportationLock(bool isLocked)
    {
        foreach (GameObject obj in teleportationController.TeleportationMarkers)
        {
            obj.GetComponent<TeleportMarkerBase>().SetLocked(isLocked);
        }
    }
}