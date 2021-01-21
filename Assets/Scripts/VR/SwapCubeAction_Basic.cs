using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** SwapCube actions.
 *
 *  @author Eduard
 */
public class SwapCubeAction_Basic : SwapCubeAction
{
    /** Only performs Swap.
     */
    public override void performAction(Transform target)
    {
        performSwap(target);
    }
}
