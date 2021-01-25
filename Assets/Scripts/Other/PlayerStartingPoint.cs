using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This script puts the player in a starting position when starting a level.
 *  @author Eduard
 */
public class PlayerStartingPoint : MonoBehaviour
{
    /** Searches for player and copies transform properties of this object onto the player. */
    void Awake()
    {
        bool mk = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) {
            // engage desktop mode, look for player inside a PlayerHolder object
            player = GameObject.FindWithTag("PlayerHolder").transform.GetChild(0).gameObject;
            mk = true;
        }
        if (player == null)
        {
            Debug.LogError("no player object was found");
            return;
        }

        player.transform.SetPositionAndRotation(transform.position, transform.rotation);
        if (mk)
            // adds extra height for desktop player to prevent out-of-bounds bug
            player.transform.position += Vector3.up;
        player.SetActive(true);
    }
}
