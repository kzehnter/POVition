using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/** This controller handles scene transitions.
 *  @author Eduard
 */
public abstract class SceneController : MonoBehaviour
{
    public string menuSceneName;
    public TeleportationController teleportationController;

    /** Puts all initial objects present in DontDestroyOnLoad. Adds event callbacks to SceneManager. */
    private void Awake()
    {
        foreach(GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            DontDestroyOnLoad(obj);
        }
        LoadMenuScene();

        SceneManager.sceneLoaded += (Scene s, LoadSceneMode sm) =>
        {
            teleportationController.InitializeTeleportation();
        };
    }

    /** Loads a new scene by name. This method may be used as a callback for OnClick events in buttons. */
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /** Loads a new scene by build index. This method may be used as a callback for OnClick events in buttons. */
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    /** Loads the menu scene. This method may be used as a callback for OnClick events in buttons. */
    public void LoadMenuScene()
    {
        LoadScene(menuSceneName);
    }

    /** Loads the scene for the next level. This method may be used as a callback for OnClick events in buttons. */
    public virtual void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            LoadScene(nextSceneIndex);
        }
        else
        {
            LoadMenuScene();
        }
    }
}
