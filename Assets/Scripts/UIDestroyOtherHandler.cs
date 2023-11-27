using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDestroyOtherHandler : MonoBehaviour
{

    [Header("Destruction Properties")]
    [SerializeField] private string _tagToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggering");
        if (collision.gameObject.CompareTag(_tagToDestroy))
        {
            Destroy(collision.gameObject);
        }
    }

}
