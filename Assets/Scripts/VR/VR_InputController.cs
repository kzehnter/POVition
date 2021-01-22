using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.Extras;

public class VR_InputController : MonoBehaviour
{
    /** cooldown time for cube teleport */
    public int swapCooldown;
    private int _swapCooldown = 0;
    
    /**   */
    private SteamVR_LaserPointer laserPointer;
    /**   */
    public SteamVR_Input_Sources m_TargetSource;
    /**   */
    public SteamVR_Action_Boolean m_OpenMenu;
    /**   */
    public Canvas pauseCanvas;

    /** adds callback to laser pointer click event. */
    private void Awake()
    {
        laserPointer = GetComponentInChildren<SteamVR_LaserPointer>();
        laserPointer.PointerClick += OnPointerClick;
    }

    /** removes all event callbacks. */
    private void OnDestroy()
    {
        laserPointer.PointerClick -= OnPointerClick;
    }

    /** updates cooldown, toggles menu. */
    void FixedUpdate()
    {
        if (_swapCooldown > 0)
        {
            _swapCooldown--;
        }

        if (m_OpenMenu.GetLastStateUp(m_TargetSource))
        {
            SetPauseMenu(!pauseCanvas.gameObject.activeSelf);

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
    
    /** 
     */
    public void SetPauseMenu(bool isOpen)
    {
        pauseCanvas.gameObject.SetActive(isOpen);
        if (isOpen)
            pauseCanvas.GetComponent<CanvasModule>().SetActivePanel("Panel_Pause");
    }
}
