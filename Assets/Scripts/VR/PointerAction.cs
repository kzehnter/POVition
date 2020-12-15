using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PointerAction : MonoBehaviour
{
    public Transform _camera;
    public SteamVR_Behaviour_Pose pose;
    public SteamVR_Action_Boolean interactWithUI = SteamVR_Input.GetBooleanAction("InteractUI");
    private int cooldown = 0;
    private Quaternion turningRotation = Quaternion.AngleAxis(180, Vector3.up);
    
    private Transform player;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        if (pose == null)
            pose = this.GetComponent<SteamVR_Behaviour_Pose>();
    }

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
