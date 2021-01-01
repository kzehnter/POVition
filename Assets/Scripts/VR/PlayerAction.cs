using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;

public class PlayerAction : MonoBehaviour
{
    /** cooldown time for cube teleport */
    [SerializeField]
    private int swapCooldown;
    private int _swapCooldown = 0;

    private SteamVR_LaserPointer laserPointer;

    /** adds callback to laser pointer click event */
    private void Awake()
    {
        laserPointer = GetComponentInChildren<SteamVR_LaserPointer>();
        laserPointer.PointerClick += OnPointerClick;
    }

    /** removes all event callbacks */
    private void OnDestroy()
    {
        laserPointer.PointerClick -= OnPointerClick;
    }

    /** updates cooldown */
    void FixedUpdate()
    {
        if (_swapCooldown > 0)
        {
            _swapCooldown--;
        }
            
    }

    /** Event callback. Triggers SwapCube interaction via laser pointer click  */
    private void OnPointerClick(object sender, PointerEventArgs args)
    {
        if (args.target.tag == "SwapCube" && _swapCooldown == 0)
        {
            args.target.GetComponent<SwapCubeAction>().performAction(transform);
            _swapCooldown = swapCooldown;
        }
    }
}
