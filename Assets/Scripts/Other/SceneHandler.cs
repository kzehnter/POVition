using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/** Used in Init Scene to load VR or MK.
 *
 *  @author Konstantin
 */
public class SceneHandler : MonoBehaviour
{
    /** Loads scene by name.
     */
    public void LoadGameScene(string name){
        SceneManager.LoadScene(name);
    }
}
