using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    private GameObject _objToDrag = null;

    /// <summary>
    /// When object is being dragged, make it follow the mouse.
    /// </summary>
    private void Update()
    {
        AttemptSelectObject();
        if (_objToDrag != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _objToDrag.transform.position = mousePos;
        }
    }

    /// <summary>
    /// When the mouse is down, try to get an object with a
    /// DraggableHandler under it. Sets _objToDrag to this object
    /// if found, else does nothing.
    /// </summary>
    private void AttemptSelectObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 1500f);
            if (hit.collider != null)
            {
                hit.collider.gameObject.TryGetComponent<DraggableHandler>(out DraggableHandler dh);
                if (dh != null)
                {
                    _objToDrag = hit.collider.gameObject;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _objToDrag = null;
        }
    }

}
