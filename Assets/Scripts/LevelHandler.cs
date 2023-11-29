using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{

    [Header("Object Assignments")]
    [SerializeField] private NextLevelHandler _nextLevelHandler;

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
        if (_nextLevelHandler != null)
        {
            _nextLevelHandler.IsInteractable = CanOpenDoor;
        }
    }

}
