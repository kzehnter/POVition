using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/** This script handles level completion.
 *  @author Eduard
 */
public class GoalBehaviour : MonoBehaviour
{
    /** Name of GameObject whose collision will trigger game completion. */
    public string goalColliderName;
    
    /** Container for level completion screen */
    public Canvas pauseCanvas;

    private PersistenceController persistenceController;

    private void Awake()
    {
        persistenceController = GameObject.Find("PersistenceController").GetComponent<PersistenceController>();
    }

    /** Engages level completion when the goal object is touched. 
     *
     *  @param other Collider
     */
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == goalColliderName)
        {
            pauseCanvas.gameObject.SetActive(true);

            // unlock next level
            persistenceController.UnlockLevel(SceneManager.GetActiveScene().buildIndex + 1);

            GameObject mkHolder = GameObject.FindWithTag("PlayerHolder");
            if (mkHolder != null)
                // if desktop mode is active, use functionality from MK_MenuControl
                mkHolder.GetComponentInChildren<MK_MenuControl>().ToggleMenu("Panel_Done");
            else
                // otherwise use CanvasModule
                pauseCanvas.GetComponent<CanvasModule>().SetActivePanel("Panel_Done");
        }
    }
}
