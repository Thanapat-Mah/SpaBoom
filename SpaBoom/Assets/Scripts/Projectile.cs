using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
        Destroy(gameObject);
     }
}
