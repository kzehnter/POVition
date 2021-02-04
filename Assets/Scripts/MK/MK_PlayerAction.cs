using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** MK Variant of PlayerAction. 
 *
 *  @author Eduard
 *  @author Konstantin
 *
 *  Event system for Player
 */
public class MK_PlayerAction : MonoBehaviour
{
    /** cooldown time for cube teleport.*/
    public int swapCooldown;
    private int _swapCooldown = 0;

    /** True if swap is happening, for usage in other scripts. */
    public static bool swapping = false;

    /** event object for Mouse catching.*/
    public MK_SwapHandler swapEvent;
    
    /** Adds callback to Swapclick event.
     */
    private void Awake() {
        swapEvent = GetComponentInChildren<MK_SwapHandler>();
        swapEvent.SwapClick += OnSwapClick;
    }
    
    /** Remove Event if player gets destroyed.  
     */
    private void OnDestroy() {
        swapEvent.SwapClick -= OnSwapClick;
    }

    /** Updates Swap cooldown.
     */
    void FixedUpdate() {
        if (_swapCooldown > 0) {
            _swapCooldown--;
            swapping = false;
        }
    }

    /** Performs Swap actions if player clicks on SwapCube.
     *  Gets called by OnSwapClick() in MK_SwapHandler
     *
     *  @param sender
     *  @param args has target for teleportation
     */
    private void OnSwapClick(object sender, SwapEventArgs args) {
        if (args.target.tag == "SwapCube" && _swapCooldown == 0) {
            swapping = true;
            args.target.GetComponent<SwapCubeAction>().performAction(transform);
            _swapCooldown = swapCooldown;
        }
    }
}
