using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.Extras;

public class PlayerAction : MonoBehaviour
{
    /** cooldown time for cube teleport */
    [SerializeField]
    private int swapCooldown;
    private int _swapCooldown = 0;

    private SteamVR_LaserPointer laserPointer;
    private Canvas menuCanvas;

    public SteamVR_Input_Sources m_TargetSource;
    public SteamVR_Action_Boolean m_OpenMenu;

    /** adds callback to laser pointer click event */
    private void Awake()
    {
        laserPointer = GetComponentInChildren<SteamVR_LaserPointer>();
        laserPointer.PointerClick += OnPointerClick;

        menuCanvas = GetComponentInChildren<Canvas>(true);
        Debug.Log(menuCanvas);
    }

    /** removes all event callbacks */
    private void OnDestroy()
    {
        laserPointer.PointerClick -= OnPointerClick;
    }

    /** updates cooldown, toggles menu */
    void FixedUpdate()
    {
        if (_swapCooldown > 0)
        {
            _swapCooldown--;
        }

        if (m_OpenMenu.GetStateUp(m_TargetSource))
        {
            menuCanvas.gameObject.SetActive(!menuCanvas.gameObject.activeSelf);
        }
            
    }

    /** Event callback. Triggers SwapCube interaction via laser pointer click  */
    private void OnPointerClick(object sender, PointerEventArgs args)
    {
        if (args.target.tag == "SwapCube" && _swapCooldown == 0)
        {
            args.target.GetComponent<SwapCubeAction>().performAction(transform);
            _swapCooldown = swapCooldown;
        }
    }
}
