using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 target;
    public float speed;

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, this.speed * Time.deltaTime);
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Boss")
        {
            Destroy(gameObject);
        }
     }
}
