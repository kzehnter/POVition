using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCubeAction_Basic : SwapCubeAction
{
    public override void performAction(Transform target)
    {
        performSwap(target);
    }
}
