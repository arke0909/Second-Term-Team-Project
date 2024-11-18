using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DeadContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DeadInteraction deadInteraction))
            deadInteraction.DeadEvent?.Invoke();
    }
}
