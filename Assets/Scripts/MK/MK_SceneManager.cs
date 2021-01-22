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
}
