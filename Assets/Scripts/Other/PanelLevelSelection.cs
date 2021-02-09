using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/** This script manages the level selection screen.
 *  @author Eduard
 */
public class PanelLevelSelection : MonoBehaviour
{
    
    public Transform prefab_levelButton;
    public Button button_PreviousPage, button_NextPage;
    
    private List<RectTransform> buttons;
    private int currentPage;
    private int totalPageCount;
    private PersistenceController persistenceController;
    
    /** Initializes variables and loads buttons. */
    private void Awake()
    {
        persistenceController = GameObject.Find("PersistenceController").GetComponent<PersistenceController>();
        buttons = new List<RectTransform>();
        currentPage = 0;
        totalPageCount = (persistenceController.Levels.Count - 1) / 10 + 1;
        LoadButtons();
    }

    /** Generates ten level buttons to be displayed on screen. */
    private void LoadButtons()
    {
        // destroy any pre-existing level buttons on screen
        if (buttons.Count != 0)
        {
            foreach (RectTransform button in buttons)
            {
                GameObject.Destroy(button.gameObject);
            }
            buttons.Clear();
        }

        // generate buttons
        for (int i=10*currentPage; i<Math.Min(persistenceController.Levels.Count, 10*(currentPage + 1)); i++)
        {
            RectTransform button = (RectTransform) Instantiate(prefab_levelButton, transform);
            button.localPosition = new Vector3(i % 5 * 100 - 200, (i % 10) / 5 * -100 + 50, 0);
            if (persistenceController.Levels[persistenceController.Levels.Keys[i]])
            {
                // keep button unlocked
                button.GetComponentInChildren<Text>().text = (i+1).ToString();
            }
            else
            {
                // lock button
                button.GetComponent<Button>().interactable = false;
                button.GetComponentInChildren<RawImage>(true).enabled = true;
            }

            int _i = i;
            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                // when button is clicked open level
                SceneManager.LoadScene(persistenceController.Levels.Keys[_i]);
            });
            buttons.Add(button);
        }
    }

    /** Load a new set of level buttons for prior levels and enable/disable paging buttons as needed. */
    public void SwitchToPreviousPage()
    {
        if (currentPage > 0)
            currentPage--;
        LoadButtons();
        if (currentPage <= 0)
            button_PreviousPage.interactable = false;
        if (currentPage == totalPageCount - 2)
            button_NextPage.interactable = true;
    }

    /** Load a new set of level buttons for next levels and enable/disable paging buttons as needed. */
    public void SwitchToNextPage()
    {
        if (currentPage < totalPageCount - 1)
            currentPage++;
        LoadButtons();
        if (currentPage == 1)
            button_PreviousPage.interactable = true;
        if (currentPage == totalPageCount - 1)
            button_NextPage.interactable = false;
    }
}
