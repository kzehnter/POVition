using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This script represents the pressure plate as a switch trigger.
 *  @author Eduard
 */
public class Switch_PressurePlate : Switch
{
    /** Animator for handling pressure plate animations. */
    private Animator animator;

    /** Event handler for press events. */
    public override event Action<bool> SwitchToggle;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    /** Puts the pressure plate in a pressed state when a SwapCube is found on top. */
    private void OnTriggerEnter(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);
        if (other.tag == "SwapCube")
        {
            animator.SetBool("isPressed", true);
            SwitchToggle.Invoke(true);
        }
    }

    /** Puts the pressure plate in a released state when the SwapCube exits the top area. */
    private void OnTriggerExit(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);
        if (other.tag == "SwapCube")
        {
            animator.SetBool("isPressed", false);
            SwitchToggle.Invoke(false);
        }
    }
}
