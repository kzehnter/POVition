using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Handels menus in Levels.
 *  
 *  @author Konstantin
 */
public class MK_MenuControl : MonoBehaviour
{
    /** Holds all in Level panels.*/
    public Canvas levelCanvas;
    
    /** Normally "Goal Cube".*/
    public string goalColliderName;

    /** Status of menu. 
     *  could be used by other scripts */  
    public static bool paused = false;
    
    /** Checks for Escape key and uses ToggleMenu.
     */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!levelCanvas.transform.GetChild(2).gameObject.activeSelf)
                ToggleMenu("Panel_Pause");
        }
    }
    
    /** Goal functionality, opens Panel_Done.
     */
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == goalColliderName) {
            ToggleMenu("Panel_Done");
        }
    }
    
    /** Opens or closes Menu, stops time, handels cursor.
     *  Takes string names of panels
     */
    public void ToggleMenu(string name){ 
        if (!paused) {
            levelCanvas.GetComponent<CanvasModule>().SetActivePanel(name);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            paused = true;
        } else {
            levelCanvas.GetComponent<CanvasModule>().SetActivePanel("Panel_UI");
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            paused = false;
        }
    }
    
    /** Toggles pause menu but doesnt lock cursor.
     */
    public void ReturnToMenu()
    {
        levelCanvas.GetComponent<CanvasModule>().SetActivePanel("Panel_UI");
        Time.timeScale = 1;
        paused = false;
    }
}
