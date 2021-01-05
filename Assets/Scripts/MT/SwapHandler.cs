using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.MT {

/**
 *  @author Konstantin
 *  @source Assets/SteamVR/Extras/SteamVR_LaserPointer.cs
 *
 */
public class SwapHandler : MonoBehaviour {
    public event SwapEventHandler MouseClick;  

    public virtual void OnMouseClick(SwapEventArgs e) {
        if (MouseClick != null) { MouseClick(this, e); }
    }

    void Update() {
        Ray raycast = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        bool bHit = Physics.Raycast(raycast, out hit);
        if (bHit) { 
            SwapEventArgs args = new SwapEventArgs();
            args.target = hit.transform; 
        }       
    }

}

public struct SwapEventArgs{
    public Transform target;
}  

public delegate void SwapEventHandler(object sender, SwapEventArgs e);
}
