using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

/** Manages actions of the laser pointer, currently only block teleportation.
 *
 *  @author Eduard
 *  @date 15.12.20
 */
public class PointerAction : MonoBehaviour
{
    /** quaternion for turning the player around after teleporting
     */
    private static readonly Quaternion turningRotation = Quaternion.AngleAxis(180, Vector3.up);
    //* Used to do ... TODO
    public Transform _camera;
    /** input device
     */
    public SteamVR_Behaviour_Pose pose;
    /** player properties
     */
    public Transform player;
    /** input key
     */
    public SteamVR_Action_Boolean interactWithUI = SteamVR_Input.GetBooleanAction("InteractUI");
    /** cooldown time for block teleport
     */
    private int cooldown = 0;
    
    /** Initializes pose.
     */
    void Start()
    {
        if (pose == null)
            pose = this.GetComponent<SteamVR_Behaviour_Pose>();
    }
    
    /** Performs raycasts from the right hand and checks for colliding blocks. Performs block teleport if interactWithUI is active.
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
