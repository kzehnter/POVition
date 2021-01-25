using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

/** This module handles general canvas functionality.
 *  @author Eduard
 */
public class CanvasModule : MonoBehaviour
{
    /** Activates the Panel inside the Canvas with the specified name, disabling all others. */
    public void SetActivePanel(string panelName)
    {
        foreach (Component component in GetComponentsInChildren<RectTransform>(true))
        {
            if (component.gameObject.transform.parent == this.gameObject.transform)
            {
                component.gameObject.SetActive(component.gameObject.name.Equals(panelName));
            }
        }
    }

    /** Quits the game. */
    public void QuitGame()
    {
        Application.Quit();
    }
}
