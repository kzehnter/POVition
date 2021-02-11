using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This controller handles teleportation assets from SteamVR.
 *  @author Eduard
 */
public class TeleportationController : MonoBehaviour
{
    /** Teleporting asset from SteamVR. */
    public Transform teleporting;

    /** All TeleportationMarkerBase objects present in the current scene. */
    public GameObject[] TeleportationMarkers { get => teleportationMarkers; }
    private GameObject[] teleportationMarkers;

    /** Handels Teleportation areas. 
     *
     *  Saves all present TeleportationMarkerBase objects to be found again 
     *  once teleportation is activated and all such objects turned inactive. */
    public void InitializeTeleportation()
    {
        teleportationMarkers = GameObject.FindGameObjectsWithTag("VR_Teleportation");
        Transform _vrTeleportation = Instantiate(teleporting);
        _vrTeleportation.parent = this.transform;
    }
}
