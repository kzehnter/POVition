using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.MK {

/** Event handler for CubeSwap.
 *
 *  @author Konstantin
 *  @source Assets/SteamVR/Extras/SteamVR_LaserPointer.cs
 *
 */
public class MK_SwapHandler : MonoBehaviour {
    /** Event object.*/
    public event SwapEventHandler SwapClick;  
    
    /** Event which can be used in other classes.
     */
    public virtual void OnSwapClick(SwapEventArgs e) {
        if (SwapClick != null) { SwapClick(this, e); }
    }

    /** Raycast object detection.
     *  ray from camera direction
     *  object saved in SwapEventArgs
     */
    void Update() {
        if (Input.GetMouseButtonDown(0)){
            Ray raycast = new Ray(transform.position, /*Camera direction*/transform.GetChild(0).forward);
            RaycastHit hit;
            bool bHit = Physics.Raycast(raycast, out hit);
            if (bHit) { 
                SwapEventArgs args = new SwapEventArgs();
                args.target = hit.transform;
                OnSwapClick(args);
            }
        }       
    }
}

/** List of Arguments for event.
 */
public struct SwapEventArgs{
    public Transform target;
}  

/** Delegate for event handler.
 */
public delegate void SwapEventHandler(object sender, SwapEventArgs e);
}
