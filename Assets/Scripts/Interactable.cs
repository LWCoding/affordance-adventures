using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    [Header("Object Run-Time Properties")]
    private bool _isInteractable;
    public bool IsInteractable {
        get => _isInteractable;
        set
        {
            _isInteractable = value;
            OnSetInteractability(_isInteractable);
        }
    }

    public abstract void OnSetInteractability(bool newVal);

}
