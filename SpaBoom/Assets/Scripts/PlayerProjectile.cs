using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Vector3 target;
    public float speed;
    
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, this.speed * Time.deltaTime);
        Destroy(gameObject,5);
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
        Destroy(gameObject);
     }
}
