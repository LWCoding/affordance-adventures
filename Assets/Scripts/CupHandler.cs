using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CupHandler : MonoBehaviour
{

    public static bool IsCupChosen;
    [Header("Cup Properties")]
    [Tooltip("The object to parent to this cup after it is lowered")]
    [SerializeField] private GameObject _objToChildAfterLower;
    [Tooltip("Cup will drop by this height at the very beginning.")]
    [SerializeField] private float _upwardsVertDistToTravel;
    [SerializeField] private bool _isCorrectCup;

    private bool _isClickable;

    private void Awake()
    {
        IsCupChosen = false;
    }

    /// <summary>
    /// Animates the cup to slowly lift by calling the related Coroutine.
    /// </summary>
    public void MoveCupUpwards()
    {
        StartCoroutine(MoveCupUpwardsByCoroutine(_upwardsVertDistToTravel));
    }

    /// <summary>
    /// Animates the cup to slowly lower by calling the related Coroutine.
    /// </summary>
    public void MoveCupDownwards()
    {
        StartCoroutine(MoveCupUpwardsByCoroutine(-_upwardsVertDistToTravel));
    }

    /// <summary>
    /// Animates the cup to a specific position over a set time.
    /// </summary>
    /// <param name="targetPos">Position to lerp towards.</param>
    /// <param name="time">Time (in seconds) for this animation.</param>
    public void LerpToPosition(Vector2 targetPos, float time)
    {
        StartCoroutine(LerpToPositionCoroutine(targetPos, time));
    }

    /// <summary>
    /// Sets whether this cup is clickable to reveal the item underneath.
    /// </summary>
    /// <param name="isClickable">True if cup should be clickable, else false</param>
    public void ToggleCupClickable(bool isClickable)
    {
        _isClickable = isClickable;
    }

    private void OnMouseDown()
    {
        if (!_isClickable || IsCupChosen) { return; }
        // Unparent the child to this cup if needed.
        if (_objToChildAfterLower != null)
        {
            _objToChildAfterLower.transform.SetParent(null);
            _objToChildAfterLower.TryGetComponent(out DraggableHandler dh);
            if (dh != null)
            {
                dh.IsDraggable = true;
            }
        }
        // Make the cup go upwards to reveal.
        IsCupChosen = true;
        MoveCupUpwards();
        // Validate the results.
        StartCoroutine(ValidateResultsCoroutine());
    }

    /// <summary>
    /// This coroutine makes the cup lower by `_initialVertDistToTravel` at the
    /// beginning of the program. This makes it so we can see what's under the
    /// cups before they fall.
    /// </summary>
    private IEnumerator MoveCupUpwardsByCoroutine(float distToTravel)
    {
        float stepsToTake = 50;
        float _stepToTravel = distToTravel / stepsToTake;
        for (int i = 0; i < stepsToTake; i++)
        {
            transform.position += new Vector3(0, _stepToTravel);
            yield return new WaitForSeconds(0.01f);
        }
        if (_objToChildAfterLower != null)
        {
            _objToChildAfterLower.transform.SetParent(transform);
        }
    }

    /// <summary>
    /// This coroutine makes the cup lerp to a specific position over a set amount
    /// of time.
    /// </summary>
    private IEnumerator LerpToPositionCoroutine(Vector2 targetPosition, float timeToWait)
    {
        float currTime = 0;
        Vector2 initPosition = transform.position;
        while (currTime < timeToWait)
        {
            currTime += Time.deltaTime;
            transform.position = Vector2.Lerp(initPosition, targetPosition, currTime / timeToWait);
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            yield return null;
        }
        transform.position = targetPosition;
    }

    /// <summary>
    /// Wait an amount of time and then render results depending on if the correct
    /// selection was made or not.
    /// </summary>
    private IEnumerator ValidateResultsCoroutine()
    {
        yield return new WaitForSeconds(1);
        if (!_isCorrectCup)
        {
            GameManager.Instance.ResetLevel();
        }
    }

}
