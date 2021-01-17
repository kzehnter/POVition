using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour
{
    public Switch trigger;
    private Animator animator;
    public bool initialStateOpen;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isOpen", initialStateOpen);
        trigger.SwitchToggle += OnPressurePlateToggle;
    }

    private void OnDestroy()
    {
        trigger.SwitchToggle -= OnPressurePlateToggle;
    }

    void OnPressurePlateToggle(bool triggered)
    {
        // invert condition when initialStateOpen true
        animator.SetBool("isOpen", triggered ^ initialStateOpen);
    }
}
