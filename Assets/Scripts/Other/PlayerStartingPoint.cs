using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingPoint : MonoBehaviour
{
    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) {
            player = GameObject.FindWithTag("PlayerHolder").transform.GetChild(0).gameObject;
        }
        if (player == null)
            Debug.LogError("no player object was found");
        else {
            player.transform.SetPositionAndRotation(transform.position, transform.rotation);
            player.SetActive(true);
        }
    }
}
