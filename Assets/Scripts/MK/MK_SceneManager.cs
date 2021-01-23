using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/** Put objects into DontDestroyOnLoad (DDOL), load scenes.
 *  
 *  @author Konstantin
 *  @author Eduard
 */
public class MK_SceneManager : MonoBehaviour
{
    /** Holder needed for proper disabling of player.*/
    public GameObject playerHolder;
    /** In DDOL for Menus. */
    public GameObject eventSystem;

    /** Put objects in DDOL and load menu. 
     */
    private void Awake()
    {
        Object.DontDestroyOnLoad(this);
        Object.DontDestroyOnLoad(playerHolder);
        Object.DontDestroyOnLoad(eventSystem);
        LoadGameScene("MK_Menu");
    }

    /** Loads scene by name.
     */
    public void LoadGameScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    /** Puts player into next scene.
     *  Checks for current scene index and adds one
     *  if last level, goes to Main Menu
     */
    public void LoadNextLevel()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        GameObject player = playerHolder.transform.GetChild(0).gameObject;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
            Cursor.lockState = CursorLockMode.Locked;
            player.SetActive(true);
            SceneManager.LoadScene(nextSceneIndex);
            player.SetActive(false);
        } else {
            player.transform.GetComponent<MK_MenuControl>().ReturnToMenu();
        }
    }
}
