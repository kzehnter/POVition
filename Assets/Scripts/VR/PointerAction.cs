using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

/** Manages Actions of pointer with laser. 
 *
 *  @author Eduard
 *  @date 15.12.20
 *
 *  TODO
 */
public class PointerAction : MonoBehaviour
{
    //* Used to do ... TODO
    public Transform _camera;
    //* TODO
    public SteamVR_Behaviour_Pose pose;
    //* TODO
    public SteamVR_Action_Boolean interactWithUI = SteamVR_Input.GetBooleanAction("InteractUI");
    //* TODO
    private int cooldown = 0;
    //* TODO
    private Quaternion turningRotation = Quaternion.AngleAxis(180, Vector3.up);
    //* TODO
    private Transform player;
    
    /** Does TODO at beginning.
     *  TODO: ganz kurze Erklärung
     */
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        if (pose == null)
            pose = this.GetComponent<SteamVR_Behaviour_Pose>();
    }
    
    /** Does TODO at every Tick.
     *  TODO: ausführliche Erklärung
     */
    void Update()
    {
        if (cooldown > 0)
            cooldown--;
        foreach (RaycastHit hit in Physics.RaycastAll(transform.position, transform.forward, 100.0f))
        {
            GameObject obj = hit.collider.gameObject;
            if (interactWithUI != null && interactWithUI.GetState(pose.inputSource))
            {
                if (obj.CompareTag("Teleportable") && cooldown == 0)
                {
                    Vector3 pos = obj.transform.position;
                    obj.SetActive(false);
                    obj.transform.position = player.position + Vector3.up;
                    player.position = pos;
                    player.rotation *= turningRotation;
                    obj.SetActive(true);
                    cooldown = 100;
                    break;
                }
            }
        }
    }
}
