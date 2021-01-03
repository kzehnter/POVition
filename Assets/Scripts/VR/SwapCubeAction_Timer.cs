using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCubeAction_Timer : SwapCubeAction
{
    [SerializeField]
    private int delayTime;

    IEnumerator waiter()
    { 
        yield return new WaitForSeconds(delayTime);   
    }
    
    public override void performAction(Transform target)
    {
        performSwap(target);
        StartCoroutine(waiter());
        performSwap(target);
    }
}
