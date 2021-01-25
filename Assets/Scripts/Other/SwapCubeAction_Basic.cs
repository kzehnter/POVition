using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This class represents the standard swap cube.
 *  @author Eduard
 */
public class SwapCubeAction_Basic : SwapCubeAction
{
    /** Only performs swap. */
    public override void performAction(Transform target)
    {
        performSwap(target);
    }
}
