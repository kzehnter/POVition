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
    private String[] vrList = {"Teleporting","VR_Player","Teleport_Area"};
    /** All objects that belong only to a MK scene.*/
    private String[] mkList = {"MK_Player"};

    /** En/Disables all objects in lists according to vr-bool.
     */
    void Awake() {    
        foreach (String vrName in vrList) {
            GameObject obj = GameObject.Find(vrName);
            obj.SetActive(vr);
        }
        foreach (String mkName in mkList) {
            GameObject obj1 = GameObject.Find(mkName);
            obj1.SetActive(!vr);
        }
    }
}
