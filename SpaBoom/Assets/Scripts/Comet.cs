using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Comet : MonoBehaviour
{
    // Event want to trigger.
    public UnityEvent onDestroyed;
    public float speed;

    private Vector3 target;

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, this.speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            onDestroyed.Invoke();   // Invoke a delegate or a function subscript to this event.
            Debug.Log("Comet destroyed");
            Destroy(gameObject);
        }
    }

    public void SetTarget(Vector3 newTarget)
    {
        this.target = newTarget;
    }
}
