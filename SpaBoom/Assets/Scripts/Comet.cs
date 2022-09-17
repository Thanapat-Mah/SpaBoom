using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Comet : MonoBehaviour
{
    // Event want to trigger.
    public UnityEvent onDestroyed;
    public float speed;

    private Vector3 _target;
    private Vector3 _posBefore;
    private Vector3 _posAfter;
    private float _distance;

    void Update()
    {
        _posBefore = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
        _posAfter = transform.position;

        // destroy comet after it reachs destination (position don't change)
        _distance = Vector3.Distance(_posBefore, _posAfter);
        if (_distance <= 0.000001)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            if(this.gameObject.CompareTag("CometStar")){
                ScoreManager.Instance.AddScore(100);
            }
            onDestroyed.Invoke();   // Invoke a delegate or a function subscript to this event.
            Destroy(gameObject);
        }
    }

    public void SetTarget(Vector3 newTarget)
    {
        _target = newTarget;
    }

    public void SetActive()
    {
        this.gameObject.SetActive(true);
    }
}
