using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/** Manages scene changes.
 *
 *  @author Konstantin
 *  @author Eduard
 */
public class MK_SceneController : SceneController
{
    /** Holder needed to find disabled player.*/
    public GameObject playerHolder;
    
    /** Puts player into next scene.
     *  current scene index + 1
     *  if last level, go to main menu
     */
    public override void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        GameObject player = playerHolder.transform.GetChild(0).gameObject;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
            Cursor.lockState = CursorLockMode.Locked;
            player.transform.GetComponent<MK_MenuControl>().ToggleMenu("Panel_Done");
            SceneManager.LoadScene(nextSceneIndex);
            player.SetActive(false);
        } else {
            player.transform.GetComponent<MK_MenuControl>().ReturnToMenu();
            player.SetActive(false);
            LoadMenuScene();
        }
    }
}
