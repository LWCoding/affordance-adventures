using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class DestroyOtherHandler : MonoBehaviour
{

    [Header("Destroyable Properties")]
    [SerializeField] private string _tagToDestroy;
    [Tooltip("Whether this object should destroy itself once colliding")]
    [SerializeField] private bool _shouldDestroyItself;

    private bool _destroyedObject = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_tagToDestroy))
        {
            if (_shouldDestroyItself && _destroyedObject) { return; }
            Destroy(collision.gameObject);
            // If we should destroy this object after rendering collision.
            if (_shouldDestroyItself)
            {
                _destroyedObject = true;
                Destroy(gameObject);
            }
        }
    }

}
