using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [Header("Object Assignments")]
    [SerializeField] private TextMeshProUGUI _levelText;
    [Header("Level Settings")]
    [SerializeField] private List<string> _levelSceneNames;

    private int _currLevelIdx = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        RenderLevel(_currLevelIdx);
    }

    private void RenderLevel(int currLevelIdx)
    {
        // Unload the previously loaded scene, if any
        if (currLevelIdx != 0)
        {
            SceneManager.UnloadSceneAsync(_levelSceneNames[currLevelIdx - 1]);
        }
        // Load the desired scene
        SceneManager.LoadScene(_levelSceneNames[currLevelIdx], LoadSceneMode.Additive);
        // Set the level text
        _levelText.text = (currLevelIdx + 1).ToString();
    }

    /// <summary>
    /// This function increments the current level and triggers the 
    /// switch to the next scene. 
    /// </summary>
    public void WinLevel()
    {
        RenderLevel(++_currLevelIdx);
    }

}
