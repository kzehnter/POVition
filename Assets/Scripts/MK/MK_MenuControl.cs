using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MK_MenuControl : MonoBehaviour
{
    /** Pause-menu. */
    public GameObject panel;
    /** Off in menu screen. */
    public GameObject crosshair;
    /** Player off in Menu */
    public GameObject player;
    /** Status of menu. */  
    public static bool paused = false;
    
    /** Checks for Escape key and uses SetPauseMenu.
     */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePauseMenu();
        }
    }
    
    /** Opens or closes Menu, stops time.
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
            Time.timeScale = 1;
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            crosshair.SetActive(true);
        }
    }
    public void ReturnToMenu()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        paused = false;
        crosshair.SetActive(true);
    }
}
