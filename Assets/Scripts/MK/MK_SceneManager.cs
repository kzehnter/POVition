using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MK_SceneManager : MonoBehaviour
{
    public Transform playerHolder;  

    private void Awake()
    {
        Object.DontDestroyOnLoad(this);
        GameObject _playerHolder = Instantiate(playerHolder).gameObject;
        Object.DontDestroyOnLoad(_playerHolder);
        _playerHolder.transform.GetChild(0).gameObject.SetActive(false);
    }
}
