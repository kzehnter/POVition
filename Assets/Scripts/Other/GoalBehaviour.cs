using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBehaviour : MonoBehaviour
{
    public string goalColliderName;
    public Canvas pauseCanvas;
    private PersistenceController persistenceController;

    private void Awake()
    {
        persistenceController = GameObject.Find("PersistenceController").GetComponent<PersistenceController>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == goalColliderName)
        {
            pauseCanvas.gameObject.SetActive(true);
            pauseCanvas.GetComponent<CanvasModule>().SetActivePanel("Panel_Done");
            persistenceController.UnlockLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
