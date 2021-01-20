using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingPoint : MonoBehaviour
{
    void Awake()
    {
        bool mk = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) {
            player = GameObject.FindWithTag("PlayerHolder").transform.GetChild(0).gameObject;
            mk = true;
        }
        if (player == null)
            Debug.LogError("no player object was found");
        else {
            player.transform.SetPositionAndRotation(transform.position, transform.rotation);
            if (mk) player.transform.position += Vector3.up;
            player.SetActive(true);
        }
    }
}
