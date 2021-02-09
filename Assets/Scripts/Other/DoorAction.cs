using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This class handles basic door behavior.
 *  
 *  @author Eduard
 */
public class DoorAction : MonoBehaviour
{
    /** Any switch component that may activate this door. */
    public Switch trigger;

    /** Animator for opening/closing animations. */
    private Animator animator;

    /** Initial door state. */
    public bool initialStateOpen;

    /** Sets proper animation state and adds event callback to trigger. */
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isOpen", initialStateOpen);
        trigger.SwitchToggle += OnPressurePlateToggle;
    }

    /** Dismisses event callback from trigger */
    private void OnDestroy()
    {
        trigger.SwitchToggle -= OnPressurePlateToggle;
    }

    /** Event callback. Changes door state to open or closed. 
     *  
     *  @param triggered 
     */
    void OnPressurePlateToggle(bool triggered)
    {
        // invert condition when initialStateOpen true
        animator.SetBool("isOpen", triggered ^ initialStateOpen);
    }
}
