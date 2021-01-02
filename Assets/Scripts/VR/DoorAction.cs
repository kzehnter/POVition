using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour
{
    public Switch trigger;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        trigger.SwitchToggle += OnPressurePlateToggle;
    }

    private void OnDestroy()
    {
        trigger.SwitchToggle -= OnPressurePlateToggle;
    }

    void OnPressurePlateToggle(bool triggered)
    {
        animator.SetBool("isOpen", triggered);
    }
}
