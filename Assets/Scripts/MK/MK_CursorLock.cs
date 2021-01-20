using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MK_CursorLock : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }
}
