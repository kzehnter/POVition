using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Swaps positions of player and goal.
 *  
 *  @author Konstantin
 *  @date 13.12.20
 *
 *  E for swapping
 */
public class Swap : MonoBehaviour
{
    /** GameObject of goal.
     *  Makes changing it's transform possible
     */
    public GameObject goalCube;
    //* temp Vector for swapping variables.
    private Vector3 swap;

    /** Checks for swap every Tick.
     *  Adjusts height of goal and player
     */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            swap = goalCube.transform.position;
            swap.y += 0.5f;
            goalCube.transform.position = transform.position;
            goalCube.transform.position -= new Vector3(0,0.5f,0);
            transform.position = swap;
        }
    }
}
