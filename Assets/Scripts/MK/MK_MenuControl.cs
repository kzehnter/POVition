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
    private bool opened = false;
    
    /** Checks for Escape key and uses SetPauseMenu.
     */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SetPauseMenu();
        }
    }
    
    /** Opens or closes Menu, stops time.
     */
    public void SetPauseMenu(){ 
        if (!opened) {
            panel.SetActive(true);
            crosshair.SetActive(false);
            Time.timeScale = 0;
            player.SetActive(false);
            opened = true;
        } else {
            panel.SetActive(false);
            crosshair.SetActive(true);
            Time.timeScale = 1;
            player.SetActive(true);
            opened = false;
        }
    }
}
