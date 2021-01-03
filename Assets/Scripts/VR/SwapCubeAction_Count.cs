using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCubeAction_Count : SwapCubeAction
{
    [SerializeField]
    private int countNumber;

    private int count;

    public override void performAction(Transform target)
    {
        if (count < countNumber){
            performSwap(target);
            count++;
        } else {
            Destroy(gameObject);
        }
    }
}
