using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.MK;

/** MK Variant of PlayerAction. 
 *
 *  @author Eduard
 *  adjusted by Konstantin
 *
 *  Event system for Player
 */
public class MK_PlayerAction : MonoBehaviour
{
    /** cooldown time for cube teleport.
     */
    [SerializeField]
    private int swapCooldown;
    private int _swapCooldown = 0;

    /** event object for Mouse catching.
     */
    private MK_SwapHandler swapEvent;
    
    /** At scene load, for EventHandler.
     */
    private void Awake() {
        swapEvent = GetComponentInChildren<MK_SwapHandler>();
        swapEvent.SwapClick += OnSwapClick;
    }
    
    /** 
     */
    private void OnDestroy() {
        swapEvent.SwapClick -= OnSwapClick;
    }

    /** Updates Swap cooldown.
     */
    void FixedUpdate() {
        if (_swapCooldown > 0) {
            _swapCooldown--;
        }
    }

    /** Performs Swap actions if player clicks on SwapCube.
     *  Gets called by OnSwapClick() in MK_SwapHandler
     */
    private void OnSwapClick(object sender, SwapEventArgs args) {
        if (args.target.tag == "SwapCube" && _swapCooldown == 0) {
            args.target.GetComponent<SwapCubeAction>().performAction(transform);
            _swapCooldown = swapCooldown;
        }
    }
}
