using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Timercube actions.
 *
 *  @author Konstantin
 */
public class SwapCubeAction_Timer : SwapCubeAction
{
    [SerializeField]
    /** Time in seconds between swaps.
     */
    private int delayTime;

    /** Waits delayTime and swaps.
     */
    IEnumerator waiter(Transform target)
    { 
        yield return new WaitForSeconds(delayTime);
        performSwap(target);   
    }
    
    /** Swap, start waiter().
     *  Startet by OnPointerClick in PlayerAction
     */
    public override void performAction(Transform target)
    {
        performSwap(target);
        StartCoroutine(waiter(target));
    }
}
