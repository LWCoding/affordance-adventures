using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class DraggableHandler : MonoBehaviour
{

    [Header("Draggable Run-time Properties")]
    public bool IsDraggable;
    public bool IsBeingDragged;

}
