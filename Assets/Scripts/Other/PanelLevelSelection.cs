using System.Collections;
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

    void Awake()
    {
        levels = new List<int>();
        buttons = new List<RectTransform>();
        for (int i=0; i<SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            if (path.Contains(scenePathPrefix))
            {
                levels.Add(SceneUtility.GetBuildIndexByScenePath(path));
            }
        }

        LoadButtons();
    }

    void LoadButtons()
    {
        for (int i=0; i<levels.Count; i++)
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
}
