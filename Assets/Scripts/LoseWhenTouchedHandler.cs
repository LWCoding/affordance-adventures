using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LoseWhenTouchedHandler : MonoBehaviour
{

    [Header("Losing Properties")]
    [SerializeField] private string _tagForLose;

    /// <summary>
    /// Whenever this collides with an object, this will
    /// trigger a level-end.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_tagForLose))
        {
            GameManager.Instance.ResetLevel();
        }
    }

}
