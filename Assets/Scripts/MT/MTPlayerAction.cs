using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.MT;

/** MT Variant of PlayerAction. 
 *
 *  @author Eduard
 *  adjusted by Konstantin
 *
 */
public class MTPlayerAction : MonoBehaviour
{
    /** cooldown time for cube teleport */
    [SerializeField]
    private int swapCooldown;
    private int _swapCooldown = 0;

    private SwapHandler swapEvent;

    private void Awake()
    {
        swapEvent = GetComponentInChildren<SwapHandler>();
        swapEvent.MouseClick += OnMouseClick;
    }

    private void OnDestroy()
    {
        swapEvent.MouseClick -= OnMouseClick;
    }

    /** updates cooldown */
    void FixedUpdate()
    {
        if (_swapCooldown > 0)
        {
            _swapCooldown--;
        }
            
    }

    private void OnMouseClick(object sender, SwapEventArgs args)
    {
        if (args.target.tag == "SwapCube" && _swapCooldown == 0)
        {
            args.target.GetComponent<SwapCubeAction>().performAction(transform);
            _swapCooldown = swapCooldown;
        }
    }
}
