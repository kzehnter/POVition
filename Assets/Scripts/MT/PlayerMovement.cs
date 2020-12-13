using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Manages Movement of player object.
 *  
 *  @author Konstantin
 *  @date 13.12.20
 *  
 *  J - K for turning, W - S for moving,
 *  adjust speed in Inspector
 */
public class PlayerMovement : MonoBehaviour
{
    /** Movement speed for player.
     *  Adjustable in Inspector,
     *  normally at 0.05
     */
    public float speed;

    /** Movement at every Tick.
     *  Forwards/Backwards with transform.Translate
     */
    void Update()
    {
        if (Input.GetKey(KeyCode.J)) transform.Rotate(0,-3,0);
        if (Input.GetKey(KeyCode.K)) transform.Rotate(0,3,0);
        transform.Translate(new Vector3(Input.GetAxis("Horizontal")*speed, 0f, Input.GetAxis("Vertical")*speed));
    }
}
