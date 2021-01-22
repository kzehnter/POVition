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

    private void Awake()
    {
        foreach(GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
            Object.DontDestroyOnLoad(obj);

        LoadGameScene("VR_Menu");
    }

    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
