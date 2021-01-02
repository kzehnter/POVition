using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour
{
    private Animator animator;

    public GameObject trigger;
    private PressurePlate _trigger;
    void Awake()
    {
        animator = GetComponent<Animator>();
        _trigger = trigger.GetComponentInChildren<PressurePlate>();
        _trigger.PressurePlateToggle += OnPressurePlateToggle;
    }

    private void OnDestroy()
    {
        _trigger.PressurePlateToggle -= OnPressurePlateToggle;
    }

    void OnPressurePlateToggle(bool triggered)
    {
        animator.SetBool("isOpen", triggered);
    }
}
