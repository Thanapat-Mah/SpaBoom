using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{ 
    public ScoreManager scoreManager;
    public Health health;
    void Start()
    {
    }
 
    void Update()
    {
        // calculate angle to rotate
        Vector3 orbVector = Camera.main.WorldToScreenPoint(transform.position);
        orbVector = Input.mousePosition - orbVector;
        float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;
 
        // rotate the object according to calculated angle
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // add score only when the health not empty yet
        if (health.GetRemainingHealth() > 0)
        {
            if (collision.gameObject.tag == "NormalBullet")
            {
                scoreManager.AddScore(10);
            }
            else if (collision.gameObject.tag == "BossBullet")
            {
                scoreManager.AddScore(15);
            }
        }
    }
}