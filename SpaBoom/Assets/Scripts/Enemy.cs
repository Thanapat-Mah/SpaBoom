using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackRate = 1;
    public Projectile bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(ShootBullet), this.attackRate, this.attackRate);
    }

    void ShootBullet()
    {
        Instantiate(this.bulletPrefab, transform.position, Quaternion.identity);
        Debug.Log("Spawn bullet");
    }
}
