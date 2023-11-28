using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartMoveHandler : MonoBehaviour
{

    [Header("Points to Move To")]
    [SerializeField] private List<Vector2> _travelPoints;
    [Header("Move Proprties")]
    [SerializeField] private float _moveSpeed;

    private int _currIdx;

    private void Awake()
    {
        _currIdx = 0;
    }

    private void Update()
    {
        Vector2 travelDest = _travelPoints[_currIdx];
        if (Vector2.Distance(transform.position, travelDest) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, travelDest, _moveSpeed * Time.deltaTime);
        } else
        {
            _currIdx = (_currIdx + 1) % _travelPoints.Count;
        }
    }

}
