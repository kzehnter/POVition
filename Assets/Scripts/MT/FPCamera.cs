using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Camera is in First Person for player
 */
public class FPCamera : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = player.position;
        transform.rotation = player.rotation;
    }
}
