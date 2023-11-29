using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class MakeInteractableHandler : MonoBehaviour
{

    [Header("Destroyable Properties")]
    [SerializeField] private string _tagToOpen;
    [Tooltip("Whether this object should destroy itself once colliding")]
    [SerializeField] private bool _shouldDestroyItself;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_tagToOpen))
        {
            collision.gameObject.TryGetComponent(out Interactable interactable);
            if (interactable != null)
            {
                AudioManager.Instance.PlaySFX(SoundEffect.DOOR_UNLOCK);
                interactable.IsInteractable = true;
                // If we should destroy this object after rendering collision.
                if (_shouldDestroyItself)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}
