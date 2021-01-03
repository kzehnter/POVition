using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCubeAction_Timer : SwapCubeAction
{
    [SerializeField]
    private int delayTime;

    IEnumerator waiter(Transform target)
    {
        performSwap(target);
        yield return new WaitForSeconds(delayTime);
        performSwap(target);
    }
    
    public override void performAction(Transform target)
    {
        StartCoroutine(waiter(target));
    }
}
