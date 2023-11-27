using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class UIDraggableHandler : MonoBehaviour, IDragHandler
{

    [Header("Draggable Run-time Properties")]
    public bool IsDraggable;

    /// <summary>
    /// When object is being dragged, make it follow the mouse.
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

}
