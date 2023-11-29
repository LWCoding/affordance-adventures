using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Jobs;
using UnityEngine;

public class CupsController : MonoBehaviour
{

    [Header("Draggable To Deactivate")]
    [Tooltip("A draggable to deactivate initially. Should be the item under the correct cup")]
    [SerializeField] private DraggableHandler _draggableToDeactivateInitially;

    private readonly List<CupHandler> _allCups = new();

    private void Awake()
    {
        // Make draggable not interactable at the beginning (e.g., the key)
        _draggableToDeactivateInitially.IsDraggable = false;
        // Find all cups by tag and add them to the _allCups list
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Cup");
        foreach (GameObject obj in allObjects)
        {
            Debug.Assert(obj.GetComponent<CupHandler>() != null, "Cup handler not found on `Cup` tagged object!", this);
            _allCups.Add(obj.GetComponent<CupHandler>());
        }
        // Make all cups unclickable
        foreach (CupHandler handler in _allCups)
        {
            handler.ToggleCupClickable(false);
        }
    }

    private void Start()
    {
        StartCoroutine(LowerAndShuffleCups());
    }

    /// <summary>
    /// Lower the cups, and then shuffle them.
    /// This Coroutine adds time in between each action so the player
    /// can actively process them.
    /// </summary>
    private IEnumerator LowerAndShuffleCups()
    {
        yield return new WaitForSeconds(1);
        // Make all cups initially lower
        foreach (CupHandler handler in _allCups)
        {
            handler.MoveCupDownwards();
        }
        yield return new WaitForSeconds(2);
        // Shuffle the cups
        StartCoroutine(ShuffleCupsCoroutine());
    }

    /// <summary>
    /// Shuffles each cup before returning them to a specific position.
    /// </summary>
    private IEnumerator ShuffleCupsCoroutine()
    {
        int randInc = Random.Range(1, _allCups.Count - 1);
        float timeToWaitPerShuffle = 0.8f;
        // Shuffle the cups by this random increment, modulo number of cups.
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < _allCups.Count; j++)
            {
                Vector2 newPos = _allCups[(j + randInc) % _allCups.Count].transform.position;
                _allCups[j].LerpToPosition(newPos, timeToWaitPerShuffle);
            }
            yield return new WaitForSeconds(timeToWaitPerShuffle);
        }
        // Make cups clickable.
        foreach (CupHandler handler in _allCups)
        {
            handler.ToggleCupClickable(true);
        }
    }

}
