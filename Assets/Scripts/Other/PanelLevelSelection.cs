using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelLevelSelection : MonoBehaviour
{
    public Transform prefab_levelButton;
    public Button button_PreviousPage, button_NextPage;
    
    private List<RectTransform> buttons;
    private int currentPage;
    private int pageCount;
    private PersistenceController persistenceController;

    private void Awake()
    {
        persistenceController = GameObject.Find("PersistenceController").GetComponent<PersistenceController>();
        buttons = new List<RectTransform>();
        currentPage = 0;
        pageCount = (persistenceController.Levels.Count - 1) / 10 + 1;
        LoadButtons();
    }

    private void LoadButtons()
    {
        if (buttons.Count != 0)
        {
            foreach (RectTransform button in buttons)
            {
                GameObject.Destroy(button.gameObject);
            }
            buttons.Clear();
        }

        for (int i=10*currentPage; i<Math.Min(persistenceController.Levels.Count, 10*(currentPage + 1)); i++)
        {
            RectTransform button = (RectTransform) Instantiate(prefab_levelButton, transform);
            button.localPosition = new Vector3(i % 5 * 100 - 200, (i % 10) / 5 * -100 + 50, 0);
            if (persistenceController.Levels[persistenceController.Levels.Keys[i]])
            {
                button.GetComponentInChildren<Text>().text = (i+1).ToString();
            }
            else
            {
                button.GetComponent<Button>().interactable = false;
                button.GetComponentInChildren<RawImage>(true).enabled = true;
            }

            int _i = i;
            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log(_i);
                SceneManager.LoadScene(persistenceController.Levels.Keys[_i]);
            });
            buttons.Add(button);
        }
    }

    public void SwitchToPreviousPage()
    {
        if (currentPage > 0)
            currentPage--;
        LoadButtons();
        if (currentPage <= 0)
            button_PreviousPage.interactable = false;
        if (currentPage == pageCount - 2)
            button_NextPage.interactable = true;
    }

    public void SwitchToNextPage()
    {
        if (currentPage < pageCount - 1)
            currentPage++;
        LoadButtons();
        if (currentPage == 1)
            button_PreviousPage.interactable = true;
        if (currentPage == pageCount - 1)
            button_NextPage.interactable = false;
    }
}
