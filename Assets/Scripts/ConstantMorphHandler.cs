using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMorphHandler : MonoBehaviour
{

    [Header("Morph Properties")]
    [SerializeField] private float _timeBetweenMorphs;
    [SerializeField] private bool _shouldStopMorphingOnClick;
    [SerializeField] private int _correctChildIdx;

    private float _currTime;
    private int _totalChildren;
    private int _currChildIdx;
    private bool _shouldBeChanging = true;

    private void Awake()
    {
        if (_shouldStopMorphingOnClick)
        {
            Debug.Assert(GetComponent<Collider2D>() != null, "Object needs collider to properly work!", this);
        }
        _totalChildren = transform.childCount;
        _currChildIdx = 0;
        RenderChild(_currChildIdx);
    }

    /// <summary>
    /// Every `timeBetweenMorphs` seconds, increment the child count
    /// and make sure ONLY that child is showing. This gives the impression
    /// of the object switching.
    /// </summary>
    private void Update()
    {
        if (!_shouldBeChanging) { return; }
        _currTime += Time.deltaTime;
        if (_currTime > _timeBetweenMorphs)
        {
            _currTime = 0;
            _currChildIdx = (_currChildIdx + 1) % _totalChildren;
            RenderChild(_currChildIdx);
        }
    }

    /// <summary>
    /// Hide all children except for the one targeted by `childIdx`.
    /// </summary>
    /// <param name="childIdx">The index of the child object to stay showing.</param>
    private void RenderChild(int childIdx)
    {
        for (int i = 0; i < _totalChildren; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == childIdx);
        }
    }

    private void OnMouseDown()
    {
        if (_shouldStopMorphingOnClick)
        {
            if (_currChildIdx != _correctChildIdx)
            {
                StartCoroutine(LoseLevelAfterSecond());
            } else
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
            _shouldBeChanging = false;
        }
    }

    private IEnumerator LoseLevelAfterSecond()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.ResetLevel();
    }

}
