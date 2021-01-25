using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MK_SceneController : SceneController
{
    public GameObject playerHolder;

    public override void LoadNextLevel()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        GameObject player = playerHolder.transform.GetChild(0).gameObject;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            Cursor.lockState = CursorLockMode.Locked;
            player.SetActive(true);
            SceneManager.LoadScene(nextSceneIndex);
            player.SetActive(false);
        }
        else
        {
            player.transform.GetComponent<MK_MenuControl>().ReturnToMenu();
        }
    }
}
