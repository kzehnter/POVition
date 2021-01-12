using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Manages Movement of player object.
 *  
 *  @author Konstantin
 *  
 *  Mouse for turning, W - S for moving,
 *  adjust movement in Inspector
 */
public class MK_PlayerMovement : MonoBehaviour
{
    /** Movement speed for player ca. 2-5.*/
    public float speed;
    /** Main Camera, for vertical adjustment.*/
    public Camera camera;
    /** Instead of rigidbody for more player options.*/
    public CharacterController player;
    /** Rotation speed, 2 is reasonable.*/
    public float xRotSpeed;
    /** Rotation speed, 2 is reasonable.*/
    public float yRotSpeed;
    /** Tracks vertical camera position.*/
    private float yRot = 0;
    /** Used to move player to ground.*/
    private float gravity = 0;

    /** Movement at every Tick.
     *  Character Controller used for movement
     *  Mouse for Orientation
     *  Player can move on ground, turn head and fall
     */
    void Update() {
        if (!transform.GetComponent<MK_PlayerAction>().getSwapping()) {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            yRot -= mouseY*yRotSpeed;
            camera.transform.localRotation = Quaternion.Euler(yRot, 0, 0);
            transform.Rotate(0, mouseX*xRotSpeed, 0); 
            gravity -= 9.81f * Time.deltaTime;
        
            // lock mouse to game window
            if (Input.GetMouseButtonDown(0)) { Cursor.lockState = CursorLockMode.Locked; }
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), gravity, Input.GetAxis("Vertical"));
            player.Move((transform.rotation * move.normalized * speed) * Time.deltaTime);
            if (player.isGrounded){gravity = 0;}
        }
    }
}
