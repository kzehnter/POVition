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
            persistenceController.UnlockLevel(SceneManager.GetActiveScene().buildIndex + 1);

            GameObject mkHolder = GameObject.FindWithTag("PlayerHolder");
            if (mkHolder != null)
                mkHolder.GetComponentInChildren<MK_MenuControl>().ToggleMenu("Panel_Done");
            else
                pauseCanvas.GetComponent<CanvasModule>().SetActivePanel("Panel_Done");
        }
    }
}
