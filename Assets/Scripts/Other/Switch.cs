using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Switch : MonoBehaviour
{
    public abstract event Action<bool> SwitchToggle;
}
