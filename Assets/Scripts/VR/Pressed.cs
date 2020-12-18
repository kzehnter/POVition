using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Manages Plate-Press and its actions
 *    
 *  @author Konstantin
 *  @date 18.12.20
 *
 *  Moves Plate down and up, makes actions happen
 */
public class Pressed : MonoBehaviour
{
    /** Object, which gets affected by Press.
     *  Can be specified in Inspector
     */
    public GameObject affectedObject;
    
    //* Number of single steps from up to down, 10 is good.
    public int smoothness;
    
    /* Tracks position of movement.
     * 0 is down, smoothness is up
     */
    int position;
    
    //* Changes position of plate.
    Vector3 movement;

    //* Setting variables.
    void Start(){
        position = smoothness;
        movement = new Vector3(0,0.1f/smoothness,0);
    }
    
    /** Checks for Player or Cube on top.
     *  true if pressed, false if not
     */
    bool PressCheck(){
        // TODO
        // https://answers.unity.com/questions/1272073/im-wondering-how-you-make-a-pressure-plate-system.html
        if (Input.GetKey(KeyCode.F)){
            return true;
        } else return false;
    }

    /** All pressure plate behaviour.
     *  Moving up and down
     */
    void Update(){ 
        if (PressCheck()){
            if (position != 0){
                position--;
                transform.position -= movement;
                // maybe add colors changes and stuff here   
            }
            // TODO: Action for affectedObject here
        } else {
            if (position != smoothness){
                position++;
                transform.position += movement;
            }
            // TODO: Action for affectedObject here
        }
    }
}
