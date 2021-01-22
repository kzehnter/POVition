using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelLevelSelection : MonoBehaviour
{
    public Transform prefab_levelButton;
    public string scenePathPrefix;

    private List<int> levels;
    private List<RectTransform> buttons;
    public Button button_PreviousPage, button_NextPage;
    private int currentPage;
    private int pageCount;

    private void Awake()
    {
        levels = new List<int>();
        buttons = new List<RectTransform>();
        currentPage = 0;
        
        for (int i=0; i<SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            if (path.Contains(scenePathPrefix))
            {
                levels.Add(SceneUtility.GetBuildIndexByScenePath(path));
            }
        }
        pageCount = (levels.Count - 1) / 10 + 1;
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

        for (int i=10*currentPage; i<Math.Min(levels.Count, 10*(currentPage + 1)); i++)
        {
            RectTransform button = (RectTransform) Instantiate(prefab_levelButton, transform);
            button.localPosition = new Vector3(i % 5 * 100 - 200, (i % 10) / 5 * -100 + 50, 0);
            button.GetComponentInChildren<Text>().text = (i+1).ToString();

            int _i = i;
            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene(levels[_i]);
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
