using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 target;
    public float speed;
    public GameObject bulletParticlePrefab;

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, this.speed * Time.deltaTime);
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
        Instantiate(bulletParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
     }
}
