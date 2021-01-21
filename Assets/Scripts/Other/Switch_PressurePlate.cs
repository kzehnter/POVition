using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_PressurePlate : Switch
{
    private Animator animator;

    public override event Action<bool> SwitchToggle;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);
        if (other.tag == "SwapCube")
        {
            animator.SetBool("isPressed", true);
            SwitchToggle.Invoke(true);
        }
        
    }

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
