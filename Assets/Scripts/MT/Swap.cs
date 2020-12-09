using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  Swaps positions of player and goal and adjusts their height
 */
public class Swap : MonoBehaviour
{
    public GameObject goalCube;
    private Vector3 swap;

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
