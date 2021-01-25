using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationInit : MonoBehaviour
{
    public Transform vrTeleportation;
    public GameObject[] teleportationMarkers;

    private void Awake()
    {
        teleportationMarkers = GameObject.FindGameObjectsWithTag("VR_Teleportation");
        Instantiate(vrTeleportation);
    }
}
