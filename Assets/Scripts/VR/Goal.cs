using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Player")) {
          // TODO end level
          Debug.Log("uWu what is u doin, step-player?"); 
        }
    }
}
