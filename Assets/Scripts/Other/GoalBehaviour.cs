using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    public string goalColliderName;
    public Canvas pauseCanvas;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == goalColliderName)
        {
            pauseCanvas.gameObject.SetActive(true);
            pauseCanvas.GetComponent<CanvasModule>().SetActivePanel("Panel_Done");
        }
    }
}
