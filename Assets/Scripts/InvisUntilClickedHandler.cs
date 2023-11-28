using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InvisUntilClickedHandler : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(1, 1, 1, 0);
    }

    private void OnMouseDown()
    {
        _spriteRenderer.color = new Color(1, 1, 1, 1);
        TryGetComponent(out ProximityDingHandler pdh);
        if (pdh != null)
        {
            pdh.enabled = false;
        }
    }

}
