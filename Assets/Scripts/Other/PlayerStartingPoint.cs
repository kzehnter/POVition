using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingPoint : MonoBehaviour
{
    void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
}