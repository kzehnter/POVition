using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationController : MonoBehaviour
{
    public Transform vrTeleportation;
    private GameObject[] teleportationMarkers;

    public GameObject[] TeleportationMarkers { get => teleportationMarkers; }

    public void InitializeTeleportation()
    {
        teleportationMarkers = GameObject.FindGameObjectsWithTag("VR_Teleportation");
        Transform _vrTeleportation = Instantiate(vrTeleportation);
        _vrTeleportation.parent = this.transform;
        Debug.Log("initialized");
    }
}
