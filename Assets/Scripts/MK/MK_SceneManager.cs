using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 *
 *
 */
public class MK_SceneManager : MonoBehaviour
{
    public GameObject playerHolder;
    public GameObject eventSystem;

    private void Awake()
    {
        Object.DontDestroyOnLoad(this);
        Object.DontDestroyOnLoad(playerHolder);
        Object.DontDestroyOnLoad(eventSystem);
        LoadGameScene("MK_Menu");
    }

    public void LoadGameScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
