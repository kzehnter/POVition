using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This base class provides functionalities common to all SwapCube types. 
 *  Any SwapCube must inherit from this type.
 *  @author Eduard
 */
public abstract class SwapCubeAction : MonoBehaviour
{
    /** Quaternion for turning the player around after teleporting. */
    private static readonly Quaternion turningRotation = Quaternion.AngleAxis(180, Vector3.up);
    
    /** Event callback for any raycaster. Performs a given action when triggered. */
    public abstract void performAction(Transform target);

    /** Swaps this transform and the target transform (player) in their position. 
     *  
     *  @param target should be Player
     */
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
