using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{

    [Header("Object Assignments")]
    [SerializeField] private Button _doorButton;

    [Header("Level Run-Time Properties")]
    public bool CanOpenDoor;

    private void Awake()
    {
        // If we've loaded a level but can't find the GameManager
        // script, then go back to the first scene.
        if (GameManager.Instance == null)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Start()
    {
        _doorButton.interactable = CanOpenDoor;
    }

    /// <summary>
    /// This function triggers the WinLevel() function in the
    /// GameManager singleton.
    /// 
    /// Raises an assertion if GameManager is not findable.
    /// </summary>
    public void WinLevel()
    {
        Debug.Assert(GameManager.Instance != null, "Can't find GameManager singleton!", this);
        GameManager.Instance.WinLevel();
    }

}
