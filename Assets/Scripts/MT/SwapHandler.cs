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
    public event SwapEventHandler SwapClick;  

    public virtual void OnSwapClick(SwapEventArgs e) {
        if (SwapClick != null) { Debug.Log("Juhuuuuuuuu"); SwapClick(this, e); }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)){
            Ray raycast = new Ray(transform.position, /*Camera direction*/transform.GetChild(0).forward);
            RaycastHit hit;
            bool bHit = Physics.Raycast(raycast, out hit);
            if (bHit) { 
                SwapEventArgs args = new SwapEventArgs();
                args.target = hit.transform;
                Debug.Log(hit.transform.name);
            }
        }       
    }

}

public struct SwapEventArgs{
    public Transform target;
}  

public delegate void SwapEventHandler(object sender, SwapEventArgs e);
}
