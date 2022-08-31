using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackRate = 1;
    public Projectile bulletPrefab;
    public LevelController levelController;

    void Start()
    {
        InvokeRepeating(nameof(ShootBullet), this.attackRate, this.attackRate);
    }

    private void ShootBullet()
    {
        // if the game is not run, don't shoot bullet
        if (levelController.GetIsGameRun())
        {
            Instantiate(this.bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
