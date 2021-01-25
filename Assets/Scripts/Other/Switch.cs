using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This base class serves as an interface for switch triggers of any kind.
 *  So far only an implementation for pressure plates exists.
 *  @author Eduard
 */
public abstract class Switch : MonoBehaviour
{
    /** Event handler for any switch toggle event. */
    public abstract event Action<bool> SwitchToggle;
}
