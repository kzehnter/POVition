using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Handels pause menu in Levels.
 *  
 *  @author Konstantin
 */
public class MK_MenuControl : MonoBehaviour
{
    /** Pause-menu. */
    public GameObject panel;
    /** Off in menu screen. */
    public GameObject crosshair;
    /** Player off in Menu */
    public GameObject player;
    /** Status of menu. 
     *  could be used by other scripts */  
    public static bool paused = false;
    
    /** Checks for Escape key and uses SetPauseMenu.
     */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePauseMenu();
        }
    }
    
    /** Opens or closes Menu, stops time, handels cursor.
     */
    public void TogglePauseMenu(){ 
        if (!paused) {
            panel.SetActive(true);
            crosshair.SetActive(false);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            paused = true;
        } else {
            panel.SetActive(false);
            crosshair.SetActive(true);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            paused = false;
        }
    }
    
    /** Doesnt lock cursor and crosshair stays off.
     */
    public void ReturnToMenu()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        paused = false;
        crosshair.SetActive(true);
    }
}
