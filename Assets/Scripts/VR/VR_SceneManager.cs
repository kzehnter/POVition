using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class VR_SceneManager : MonoBehaviour
{


    private void Awake()
    {
        Object.DontDestroyOnLoad(this);
        LoadMenuScene();
    }

    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("VR_Menu");
    }

}
