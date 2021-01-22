using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

/**
 *
 *
 */
public class VR_SceneManager : MonoBehaviour
{
    public const string SCENE_MENU = "VR_Menu";

    private void Awake()
    {
        foreach(GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
            Object.DontDestroyOnLoad(obj);

        LoadGameScene(SCENE_MENU);
    }

    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            LoadGameScene(SCENE_MENU);
        }
    }
}
