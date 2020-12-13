using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Manages Movement of player object
 *  J - K for turning
 *  W - S for moving
 *  Adjust speed in Inspector
 */
public class PlayerMovement : MonoBehaviour
{
    public float speed;

    void Update()
    {
        if (Input.GetKey(KeyCode.J)) transform.Rotate(0,-3,0);
        if (Input.GetKey(KeyCode.K)) transform.Rotate(0,3,0);
        transform.Translate(new Vector3(Input.GetAxis("Horizontal")*speed, 0f, Input.GetAxis("Vertical")*speed));
    }
}
