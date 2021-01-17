using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** En/Disables gameobjects according to VR/MK.
 *
 *  @author Konstantin
 *  add new changes to vrList or mkList
 */
public class VR_MK_Handler : MonoBehaviour {
    /** Should be True if VR, false if MK.*/
    public bool vr;
    /** All objects that belong only to a VR scene.*/
    private String[] vrList = {"Teleporting","VR_Player","Teleport Area","TeleportPoint", "VR_Canvas"};
    /** All objects that belong only to a MK scene.*/
    private String[] mkList = {"MK_Player","MK_Canvas"};

    /** En/Disables all objects in lists according to vr-bool.
     */
    void Awake() {
        foreach (String name in mkList) {
            GameObject obj = GameObject.Find(name);
            obj.SetActive(!vr);
        }
        foreach (String name in vrList) {
            GameObject obj = GameObject.Find(name);
            obj.SetActive(vr);
        }
    }
}
