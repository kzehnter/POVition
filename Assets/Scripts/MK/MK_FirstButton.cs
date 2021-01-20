using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MK_FirstButton : MonoBehaviour
{  
    public Button button;
    
    void Start()
    {
        button.Select();    
    }

    void OnEnable() {
        button.Select();
    }
}
