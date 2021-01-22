using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class VR_InteractionLock : MonoBehaviour
{
    public GameObject raycaster;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider: " + other.gameObject.name);
        if (other.gameObject.GetComponentInParent<HandCollider>() == null)
        {
            Debug.Log("is not part of controller: " + other.gameObject.name);
            SetTeleportationLock(true);
            raycaster.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("collider: " + other.gameObject.name);
        if (other.gameObject.GetComponentInParent<HandCollider>() == null)
        {
            Debug.Log("is not part of controller: " + other.gameObject.name);
            SetTeleportationLock(false);
            raycaster.SetActive(true);
        }
    }

    private void SetTeleportationLock(bool isLocked)
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("VR_Teleportation"))
        {
            Debug.Log(obj.name);
            obj.GetComponent<TeleportMarkerBase>().SetLocked(isLocked);
        }
    }
}