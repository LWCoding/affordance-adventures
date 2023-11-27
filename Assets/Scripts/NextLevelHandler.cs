using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelHandler : Interactable
{

    [Header("Object Assignments")]
    [SerializeField] private Sprite _lockedSprite;
    [SerializeField] private Sprite _unlockedSprite;
    [SerializeField] private Sprite _selectedSprite;

    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// Updates the door's sprite to locked or unlocked depending on the
    /// interactability of this object.
    /// </summary>
    private void UpdateDoorSprite()
    {
        _spriteRenderer.sprite = IsInteractable ? _unlockedSprite : _lockedSprite;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        if (IsInteractable)
        {
            _spriteRenderer.sprite = _selectedSprite;
        } else
        {
            UpdateDoorSprite();
        }
    }

    private void OnMouseExit()
    {
        UpdateDoorSprite();
    }

    private void OnMouseDown()
    {
        if (IsInteractable)
        {
            GameManager.Instance.WinLevel();
        }
    }

    public override void OnSetInteractability(bool newVal)
    {
        UpdateDoorSprite();
    }
}
