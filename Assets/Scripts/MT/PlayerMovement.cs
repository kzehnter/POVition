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
public class PlayerMovement : MonoBehaviour
{
    /** Movement speed for player.
     *  2-5 realistic
     */
    public float speed;
    /** Main Camera, for vertical adjustment.
     */
    public Camera camera;
    /** Instead of rigidbody for more player options.
     */
    public CharacterController player;
    /** Rotation speed, 2 is reasonable.
     */
    public float xRotSpeed;
    /** Rotation speed, 2 is reasonable.
     */
    public float yRotSpeed;
    /** Tracks vertical camera position.
     */
    private float yRot = 0;


    /** Movement at every Tick.
     *  Forwards/Backwards with transform.Translate
     */
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        yRot -= mouseY*yRotSpeed;
        camera.transform.localRotation = Quaternion.Euler(yRot, 0, 0);
        transform.Rotate(0, mouseX*xRotSpeed, 0); 
        
        // lock mouse to game window
        if (Input.GetMouseButtonDown(0)) { Cursor.lockState = CursorLockMode.Locked; }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        player.Move((transform.rotation * move.normalized * speed) * Time.deltaTime);
    }
}
