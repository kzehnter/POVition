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

    private void Awake()
    {
        Object.DontDestroyOnLoad(this);
        Object.DontDestroyOnLoad(playerHolder);
    }

    public void LoadGameScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
