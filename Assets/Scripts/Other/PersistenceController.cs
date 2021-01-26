using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/** This controller manages persistence for in-game level progress.
 *  @author Eduard
 */
public class PersistenceController : MonoBehaviour
{
    /** File path prefix for level scenes. */
    public string scenePathPrefix;

    /** Sorted list of levels found in the build containing build index (key) and lock state (value). */
    public SortedList<int, bool> Levels { get => levels; }
    private SortedList<int, bool> levels;

    /** Initializes SortedList levels. */
    private void Awake()
    {
        levels = new SortedList<int, bool>();
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            
            if (path.Contains(scenePathPrefix))
            {
                levels.Add(SceneUtility.GetBuildIndexByScenePath(path), false);
            }
        }

        // unlock first level
        UnlockLevel(levels.Keys[0]);
    }

    /** Unlocks level scene with the given build index if such entry is found. */
    public void UnlockLevel(int buildIndex)
    {
        if (levels.ContainsKey(buildIndex))
            levels[buildIndex] = true;
    }
}
