using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Comet : MonoBehaviour
{
    // Event want to trigger.
    public UnityEvent onDestroyed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            onDestroyed.Invoke();   // Invoke a delegate or a function subscript to this event.
            Debug.Log("Comet destroyed");
            Destroy(gameObject);
        }
    }
}
