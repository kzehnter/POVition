using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

/** This controller manages inputs in vr mode.
 *  @author Eduard
 */
public class VR_InputController : MonoBehaviour
{
    /** cooldown time for cube teleport in ticks */
    public int swapCooldown;
    private int _swapCooldown = 0;
    
    /** Handels laserpointer events.*/
    private SteamVR_LaserPointer laserPointer;
    public SteamVR_Input_Sources m_TargetSource;
    public SteamVR_Action_Boolean m_OpenMenu;
    /** Holds pause panels. */
    public Canvas pauseCanvas;

    /** Adds callback to laser pointer click event. */
    private void Awake()
    {
        laserPointer = GetComponentInChildren<SteamVR_LaserPointer>();
        laserPointer.PointerClick += OnPointerClick;
    }

    /** Removes all event callbacks. */
    private void OnDestroy()
    {
        laserPointer.PointerClick -= OnPointerClick;
    }

    /** Updates cooldown, toggles menu on click. */
    void Update()
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

    /** Event callback. Triggers SwapCube interaction via laser pointer click. 
     *  
     *  @param sender
     *  @param args holds teleport target
     */
    private void OnPointerClick(object sender, PointerEventArgs args)
    {
        if (args.target.tag == "SwapCube" && _swapCooldown == 0)
        {
            args.target.GetComponent<SwapCubeAction>().performAction(transform);
            _swapCooldown = swapCooldown;
        }
    }
    
    /** (De)activates pause canvas and panel. 
     *  
     *  @param isOpen bool
     */
    private void SetPauseMenu(bool isOpen)
    {
        pauseCanvas.gameObject.SetActive(isOpen);
        if (isOpen)
            pauseCanvas.GetComponent<CanvasModule>().SetActivePanel("Panel_Pause");
    }
}
