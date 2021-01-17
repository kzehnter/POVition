using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwapCubeAction : MonoBehaviour
{
    /** quaternion for turning the player around after teleporting */
    private static readonly Quaternion turningRotation = Quaternion.AngleAxis(180, Vector3.up);
    
    /** performs a given action when triggered by a laser pointer */
    public abstract void performAction(Transform target);

    /** swaps this and target transform in their position */
    public void performSwap(Transform target)
    {
        Vector3 pos = transform.position;
        transform.gameObject.SetActive(false);
        transform.position = target.position + Vector3.up*1.35f;
        target.position = pos;
        target.rotation *= turningRotation;
        transform.gameObject.SetActive(true);
    }
}
